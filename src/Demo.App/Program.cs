Bake.New
    .Service(
        authentications: [],
        business: c => c.DomainAssemblies(typeof(Worklog).Assembly),
        cors: c => c.AspNetCore("http://localhost:3000"),
        database: c => c.Sqlite("Demo.App.db"),
        theme: c => c.Custom()
    )
    .Run();
