Bake.New
    .Service(
        authentications: [],
        business: c => c.DomainAssemblies(typeof(Empty).Assembly),
        database: c => c.Sqlite("Demo.App.db")
    )
    .Run();
