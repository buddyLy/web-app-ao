using System.Net.Http;
using System.Net.Http.Headers;

namespace Walmart.Assortment.AssortmentOptimizationSystem.Web.Helpers
{
	public static class HttpResponseMessageExtensions
	{
		public static void AddFileAttachemntContent(this HttpResponseMessage response, string fileName, byte[] fileContent, string mimeType) {
			response.Content = new ByteArrayContent(fileContent);
		    response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
		    {
		        FileName = fileName ?? "file"
		    };
		    response.Content.Headers.ContentType = new MediaTypeHeaderValue(mimeType);
		}
	}
}