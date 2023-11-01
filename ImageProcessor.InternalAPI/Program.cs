using ImageProcessor.InternalAPI.Controllers;
using ImageProcessor.InternalAPI.RequestModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        var effectsController = new EffectsController();
        var imagesController = new ImagesController();

        var jsonString = File.ReadAllText("appSettings.json");
        var jsonObject = JObject.Parse(jsonString);
        var effectsToLaunch = jsonObject["Effects"]["LoadOnLaunch"].ToObject<string[]>();

        var listener = new HttpListener();
        listener.Prefixes.Add("http://localhost:8080/");
        listener.Start();

        Console.WriteLine("Listening...");

        while (true)
        {
            var context = listener.GetContext();
            var request = context.Request;
            var response = context.Response;
            string responseContent = "";

            if (request.Url.AbsolutePath == "/effects/get")
            {
                responseContent = effectsController.GetEffects(effectsToLaunch);
            }

            if(request.Url.AbsolutePath == "/images/applyeffects")
            {
                ModifyImagesRequest modifyImagesRequest = new ModifyImagesRequest();
                using (var reader = new StreamReader(request.InputStream))
                {
                    string requestBody = reader.ReadToEnd();
                    modifyImagesRequest = JsonConvert.DeserializeObject<ModifyImagesRequest>(requestBody);
                }

                var modifiedImages = imagesController.ApplyEffect(modifyImagesRequest);
                responseContent = modifiedImages.ToString();  
            }

            var buffer = Encoding.UTF8.GetBytes(responseContent);
            response.ContentLength64 = buffer.Length;
            var responseOutput = response.OutputStream;
            responseOutput.Write(buffer, 0, buffer.Length);
            responseOutput.Close();
        }
    }
}
