Experiment with using Mediator on an OrchardCore solution.

Two issues:

1. Uncomment the following on Program.cs. It throws an error when resolving services like ShellSettings.

```
builder.Services.AddMediator(opts =>
{
    opts.ServiceLifetime = ServiceLifetime.Transient;
});
```

2. If instead try to AddMediator on each Feature project, it will conflict with itself.

<img width="983" alt="image" src="https://github.com/user-attachments/assets/6abb6cf5-45ef-454a-96ee-3699146f3c8a" />

This second approach is how I have a working setup with MediatR.
