var builder = WebApplication.CreateBuilder(args);


//activating the mvc pattern
builder.Services.AddControllersWithViews();

//activates the sessions options
builder.Services.AddSession(options =>
{
    options.Cookie.Name = ".AdventureWorks.Session";
    options.IdleTimeout = TimeSpan.FromSeconds(10);
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

//aktivates wwwroot
app.UseStaticFiles();
app.UseRouting();

//activates sessions
app.UseSession();

// Routing canges the ground routing
app.MapControllerRoute(
    name: "default",

    //home is the first defult route the action is index and id I'm not using
    //So it always takes us to the controller for home and then the page index, if we changed action to about
    // we would be taken to the about page
    //and if we had more then one controller we could chose to use that insted
    pattern: "{controller=home}/{action=index}/{id?}"
);

app.Run();