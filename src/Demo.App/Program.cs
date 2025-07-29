Bake.New
    .Service(
        authentications: [],
        business: c => c.DomainAssemblies(typeof(Worklog).Assembly),
        database: c => c.Sqlite("Demo.App.db"),
        configure: app =>
        {
            app.Features.Add(new UiCustomizations());
        }
    )
    .Run();
