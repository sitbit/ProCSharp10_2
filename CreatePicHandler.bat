dotnet new wpf -lang c# -f net6.0 -n PictureHandlerWithAsyncAwait -o PictureHandlerWithAsyncAwait
dotnet sln .\ProCharp10_2.sln add .\PictureHandlerWithAsyncAwait
dotnet add PictureHandlerWithAsyncAwait package System.Drawing.Common