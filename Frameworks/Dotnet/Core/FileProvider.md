# File Provider
File Provider is an abstract class to access class in a uniform way and interact with file systems in ASP.NET Core and other related frameworks.

File Provider allows you to access file information, read file contents, and perform operations like `listing directories`(logically) and checking file existence.

File Provider abstracts the underlying file system implementation, enabling you to work with different file systems such as the physical file system, embedded resources, or remote storage.

## File Provider Attributes
IFileInfo provides methods and properties for working with files:
* Exists
* IsDirectory
* Name
* Length
* LastModified
* CreateReadStream
## Common Concrete implementations
|  |  |
|:--- |:--- |
|PhysicalFileProvider| Used to provide combined access to files and directories from one or more other providers.|
|EmbeddedFileProvider|Used to access files embedded in assemblies.|
|CompositeFileProvider|Used to access the system's physical files.|

### PhysicalFileProvider Code
```csharp
using Microsoft.Extensions.FileProviders;
// Create a file provider for the physical file system
var fileProvider = new PhysicalFileProvider("C:\\path\\to\\files");
// Get a reference to a file
var fileInfo = fileProvider.GetFileInfo("myfile.txt");

// Check if the file exists
if (fileInfo.Exists)
{
    // Read the file contents
    using (var stream = fileInfo.CreateReadStream())
    {
        // Read from the stream
    }
}

// List all files in a directory
var directoryContents = fileProvider.GetDirectoryContents("mydirectory");
foreach (var file in directoryContents)
{
    // Access file information
}
```

### Manifest Embedded File Provider
```xml
<Project Sdk="Microsoft.NET.Sdk.Web">

  <PropertyGroup>
    ...
    <GenerateEmbeddedFilesManifest>true</GenerateEmbeddedFilesManifest>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="Microsoft.Extensions.FileProviders.Embedded" Version="3.1.0" />
  </ItemGroup>

  <ItemGroup>
    <EmbeddedResource Include="Resource.txt" />
  </ItemGroup>

</Project>
```
```csharp
var embeddedProvider = new EmbeddedFileProvider(typeof(Startup).Assembly);
```

## Composite File Provider
```csharp
var physicalProvider = _env.ContentRootFileProvider;
var manifestEmbeddedProvider = 
    new ManifestEmbeddedFileProvider(typeof(Program).Assembly);
var compositeProvider = 
    new CompositeFileProvider(physicalProvider, manifestEmbeddedProvider);

services.AddSingleton<IFileProvider>(compositeProvider);
```

## Watch for changes
IFileProvider provide `Watch` method to watch one or more files or directories for changes. Watch method return an `IChangeToken` object, the object contains a `HasChanged` property and a `RegisterChangeCallback` method. The RegisterChangeCallback method is invoked when a file at the specified path undergoes changes.
* The `HasChanged` property is used to indicate whether the file at the specified path has changed since the last check or callback invocation. It is a Boolean property that is set to true when changes are detected and false otherwise.
* The `RegisterChangeCallback` method allows you to register a callback or delegate that will be called when changes occur in the specified file. This method enables you to define custom logic or actions to be executed in response to the detected changes.

IChangeToken do not continuously watch for file changes by default, to implementent this functunality re-register the callback is required.
```csharp
public class FileWatcher
{
    private readonly IFileProvider _fileProvider;
    private readonly string _filePath;
    private IDisposable _changeToken;

    public FileWatcher(IFileProvider fileProvider, string filePath)
    {
        _fileProvider = fileProvider;
        _filePath = filePath;
    }

    public void StartWatching()
    {
        var fileInfo = _fileProvider.GetFileInfo(_filePath);

        if (fileInfo.Exists)
        {
            _changeToken = _fileProvider.Watch(_filePath);
            _changeToken.RegisterChangeCallback(OnFileChanged, null);
        }
    }

    private void OnFileChanged(object state)
    {
        // File has changed, handle the event
        // ...

        // Re-register the change callback to continue watching
        _changeToken.RegisterChangeCallback(OnFileChanged, null);
    }

    public void StopWatching()
    {
        _changeToken?.Dispose();
    }
}
```

## Watch online|docker file
By default, ASP.NET Core uses a file watcher that relies on the operating system's file change notifications. However, in certain scenarios, such as when running in a container or a network file system, the default file watcher may not work reliably.  In such cases, enabling the `DOTNET_USE_POLLINGFILEWATCHER` environment variable can help.
```csharp
public class OnlineFileWatcher
{
    private readonly string _fileUrl;
    private readonly TimeSpan _pollingInterval;
    private CancellationTokenSource _cancellationTokenSource;

    public OnlineFileWatcher(string fileUrl, TimeSpan pollingInterval)
    {
        _fileUrl = fileUrl;
        _pollingInterval = pollingInterval;
    }

    public void StartWatching()
    {
        _cancellationTokenSource = new CancellationTokenSource();
        WatchForChangesAsync(_cancellationTokenSource.Token);
    }

    public void StopWatching()
    {
        _cancellationTokenSource?.Cancel();
    }

    private async Task WatchForChangesAsync(CancellationToken cancellationToken)
    {
        string currentContent = await FetchFileContentAsync();

        while (!cancellationToken.IsCancellationRequested)
        {
            await Task.Delay(_pollingInterval, cancellationToken);

            try
            {
                string updatedContent = await FetchFileContentAsync();

                if (currentContent != updatedContent)
                {
                    // File has changed, handle the event
                    // ...

                    currentContent = updatedContent;
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions during file fetching
                // ...
            }
        }
    }

    private async Task<string> FetchFileContentAsync()
    {
        using (var httpClient = new HttpClient())
        {
            var response = await httpClient.GetAsync(_fileUrl);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                // Handle unsuccessful response
                // ...
                return string.Empty;
            }
        }
    }
}
```

# Reference
https://learn.microsoft.com/en-us/aspnet/core/fundamentals/file-providers?view=aspnetcore-7.0

 

