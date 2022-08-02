using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using ServiceRequest.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ServiceRequest
{
    public class HttpRequest
    {
        public const String METHOD_POST = "POST";
        public const String METHOD_GET = "GET";
        public const String METHOD_PUT = "PUT";
        private String BASE_URL;
        private RestClient client;
        private CredentialCache credentialCacheCaptureFace;
        public static int m_iHttpTimeOut = 500000;

        public HttpRequest() { }
        public HttpRequest(String BASE_URL)
        {
            this.BASE_URL = BASE_URL;

            client = new RestClient(BASE_URL);
        }
        public HttpRequest(String BASE_URL, String username, String password)
        {
            this.BASE_URL = BASE_URL;

            client = new RestClient(BASE_URL);
        }

        /* hanya digunakan untuk capture face data */
        public string HttpCapData(string strUserName, string strPassword, string url, string filePath, string request, string filename)
        {
            string responseContent = string.Empty;
            var memStream = new MemoryStream();
            var webRequest = (HttpWebRequest)WebRequest.Create(url);

            credentialCacheCaptureFace = new CredentialCache();
            credentialCacheCaptureFace.Add(new Uri(url), "Digest", new NetworkCredential(strUserName, strPassword));

            webRequest.Credentials = credentialCacheCaptureFace;
            webRequest.Timeout = m_iHttpTimeOut;
            webRequest.Method = "POST";
            webRequest.Accept = "text/html, application/xhtml+xml,";
            webRequest.Headers.Add("Accept-Language", "zh-CN");
            webRequest.ContentType = "application/xml";
            webRequest.UserAgent = "Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; WOW64; Trident/5.0)";
            webRequest.Headers.Add("Accept-Encoding", "gzip, deflate");
            webRequest.Headers.Add("Cache-Control", "no-cache");

            var contentLine = Encoding.ASCII.GetBytes("\r\n");
            memStream.Write(contentLine, 0, contentLine.Length);

            // write json message
            var byXml = Encoding.UTF8.GetBytes(request);
            memStream.Write(byXml, 0, byXml.Length);
            memStream.Write(contentLine, 0, contentLine.Length);
            webRequest.ContentLength = memStream.Length;

            var requestStream = webRequest.GetRequestStream();

            memStream.Position = 0;
            var tempBuffer = new byte[memStream.Length];
            memStream.Read(tempBuffer, 0, tempBuffer.Length);
            memStream.Close();

            requestStream.Write(tempBuffer, 0, tempBuffer.Length);
            requestStream.Close();

            try
            {
                WebResponse wr = webRequest.GetResponse();
                string szContentType = wr.ContentType;
                byte[] szResponse = new byte[wr.ContentLength];
                byte[] buf = new byte[1024];
                int iRet = -1;
                int len = 0;
                while ((iRet = wr.GetResponseStream().Read(buf, 0, 1024)) > 0)
                {
                    Array.Copy(buf, 0, szResponse, len, iRet);
                    len += iRet;
                }

                int startIndex = 0, endIndex = 0;
                byte[] byTmp = new byte[17];
                byte[] byTmp2 = new byte[4];
                string szTmp = string.Empty;
                for (; endIndex + 17 < szResponse.Length; endIndex++)
                {
                    Buffer.BlockCopy(szResponse, endIndex, byTmp, 0, 17);
                    szTmp = Encoding.UTF8.GetString(byTmp);
                    if (szTmp.Equals("\r\n--MIME_boundary")) break;
                }
                endIndex += 17;

                string strpath = null;
                DateTime dt = DateTime.Now;
                if (filePath.Equals(string.Empty))
                    filePath = Environment.CurrentDirectory;

                strpath = filePath.EndsWith("/") ? filePath + filename : filePath + "/" + filename;
                if (System.IO.File.Exists(strpath))
                {
                    File.Delete(strpath);
                }

                try
                {
                    using (FileStream fs = new FileStream(strpath, FileMode.OpenOrCreate))
                    {
                        while (true)
                        {
                            for (; startIndex + 4 < szResponse.Length; startIndex++)
                            {
                                Buffer.BlockCopy(szResponse, startIndex, byTmp2, 0, 4);
                                szTmp = Encoding.UTF8.GetString(byTmp2);
                                if (szTmp.Equals("\r\n\r\n")) break;
                            }
                            startIndex += 4;
                            for (; endIndex + 17 < szResponse.Length; endIndex++)
                            {
                                Buffer.BlockCopy(szResponse, endIndex, byTmp, 0, 17);
                                szTmp = Encoding.UTF8.GetString(byTmp);
                                if (szTmp.Equals("\r\n--MIME_boundary")) break;
                            }

                            if (startIndex >= szResponse.Length || endIndex >= szResponse.Length) break;
                            fs.Write(szResponse, startIndex, endIndex - startIndex);
                            endIndex += "\r\n--MIME_boundary".Length;
                            if (startIndex >= szResponse.Length || endIndex >= szResponse.Length) break;
                        }
                        fs.Close();
                        responseContent = strpath;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw new HttpRequestExceptions(400, "Capture face data failed", e.Message);
                }
            }
            catch (WebException ex)
            {
                Console.WriteLine(ex);
                throw new HttpRequestExceptions(400, "Request Capture face data failed", ex.Message);
            }

            webRequest.Abort();

            return responseContent;
        }

        private Dictionary<String, Object> exec(String url, Dictionary<String, Object> payload, Dictionary<String, Object> headers, String method)
        {
            return exec(url, payload, headers, new Dictionary<String, Object>(), method);
        }
        private Dictionary<String, Object> exec(String url, Dictionary<String, Object> payload, Dictionary<String, Object> headers,
            Dictionary<String, Object> files, String method)
        {

            var request = new RestRequest(url);
            foreach (var key in headers.Keys)
            {
                request.AddHeader(key, headers[key].ToString());
            }

            if (headers.ContainsKey("Accept"))
            {
                if (headers["Accept"].Equals("application/json"))
                {
                    request.AddParameter("application/json", JsonConvert.SerializeObject(payload), ParameterType.RequestBody);
                }
                else if (headers["Accept"].Equals("application/xml"))
                {
                    request.AddParameter("application/xml", payload["data"], ParameterType.RequestBody);
                }
                else if (headers["Accept"].Equals("multipart/form-data"))
                {
                    request.AddHeader("Content-Type", "multipart/form-data");
                    foreach (var key in payload.Keys)
                    {
                        request.AddParameter(key, payload[key], "application/json", ParameterType.RequestBody);
                    }

                    foreach (var key in files.Keys)
                    {
                        request.AddFile(key, files[key].ToString(), "image/jpeg");
                    }
                }
                else
                {
                    foreach (var key in payload.Keys)
                    {
                        request.AddParameter(key, payload[key]);
                    }
                }
            }
            else if (headers.ContainsKey("Content-Type"))
            {
                if (headers["Content-Type"].Equals("multipart/form-data"))
                {
                    foreach (var key in payload.Keys)
                    {
                        request.AddParameter(key, payload[key], ParameterType.QueryString);
                    }

                    foreach (var key in files.Keys)
                    {
                        request.AddFile(key, files[key].ToString());
                    }
                }
                else
                {
                    foreach (var key in payload.Keys)
                    {
                        request.AddParameter(key, payload[key]);
                    }
                }
            }
            else
            {
                foreach (var key in payload.Keys)
                {
                    request.AddParameter(key, payload[key]);
                }
            }

            IRestResponse response;
            if (method.Equals(METHOD_POST))
            {
                response = client.Post(request);
            }
            else if (method.Equals(METHOD_PUT))
            {
                response = client.Put(request);
            }
            else
            {
                response = client.Get(request);
            }

            String responseString = response.Content;
            /* clean response */
            responseString = responseString.Replace("\t", "").Replace("\n", "");
            int statusCode = (int)response.StatusCode;
            Dictionary<String, Object> ret = new Dictionary<string, object>();
            ret.Add("status", statusCode);
            ret.Add("data", responseString);
            return ret;
        }

        public Dictionary<String, Object> execReturnDictionary(String url, Dictionary<String, Object> payload, Dictionary<String, Object> headers, String method)
        {
            return execReturnDictionary(url, payload, headers, new Dictionary<String, Object>(), method);
        }

        public Dictionary<String, Object> execReturnDictionary(String url, Dictionary<String, Object> payload, Dictionary<String, Object> headers, Dictionary<String, Object> files, String method)
        {
            Dictionary<String, Object> ret = exec(url, payload, headers, files, method);
            int code = Int32.Parse(ret["status"].ToString());

            if (code != 200)
            {
                try
                {
                    Dictionary<String, Object> err = JsonConvert.DeserializeObject<Dictionary<String, Object>>(ret["data"].ToString());

                    if (err.ContainsKey("errorMsg"))
                    {
                        Console.WriteLine("Error:: " + err["errorMsg"].ToString());
                        throw new HttpRequestExceptions(code, err["errorMsg"].ToString(), err);
                    }
                    else
                    {
                        Console.WriteLine("Error:: " + err["message"].ToString());
                        throw new HttpRequestExceptions(code, err["message"].ToString(), err);
                    }
                }
                catch (Exception e)
                {
                    throw new HttpRequestExceptions(code, ret["data"].ToString(), ret);
                }
            }
            else return JsonConvert.DeserializeObject<Dictionary<String, Object>>(ret["data"].ToString());
        }

        public List<Dictionary<String, Object>> execReturnList(String url, Dictionary<String, Object> payload, Dictionary<String, Object> headers, String method)
        {
            Console.WriteLine(url);
            Dictionary<String, Object> ret = exec(url, payload, headers, method);
            int code = Int32.Parse(ret["status"].ToString());
            if (code != 200)
            {
                Dictionary<String, Object> err = JsonConvert.DeserializeObject<Dictionary<String, Object>>(ret["data"].ToString());
                Console.WriteLine("Error:: " + err["message"].ToString());
                throw new HttpRequestExceptions(code, err["message"].ToString(), err);
            }
            else
            {
                var data = JObject.Parse(ret["data"].ToString());
                string hasil = JsonConvert.SerializeObject(data["data"], Formatting.Indented);
                Console.WriteLine(hasil);
                return JsonConvert.DeserializeObject<List<Dictionary<String, Object>>>(hasil);
            }
        }

        public int execReturnInt(String url, Dictionary<String, Object> payload, Dictionary<String, Object> headers, String method)
        {
            Dictionary<String, Object> ret = exec(url, payload, headers, method);
            int code = Int32.Parse(ret["status"].ToString());

            if (code != 200)
            {
                Dictionary<String, Object> err = JsonConvert.DeserializeObject<Dictionary<String, Object>>(ret["data"].ToString());
                Console.WriteLine("Error:: " + err["message"].ToString());
                throw new HttpRequestExceptions(code, err["message"].ToString(), err);
            }
            else return Int32.Parse(ret["data"].ToString());
        }

        public String execReturnString(String url, Dictionary<String, Object> payload, Dictionary<String, Object> headers, String method)
        {
            return execReturnString(url, payload, headers, new Dictionary<String, Object>(), method);
        }

        public String execReturnString(String url, Dictionary<String, Object> payload, Dictionary<String, Object> headers, Dictionary<String, Object> file, String method)
        {
            Dictionary<String, Object> ret = exec(url, payload, headers, file, method);
            int code = Int32.Parse(ret["status"].ToString());

            if (code != 200)
            {
                Dictionary<String, Object> err = JsonConvert.DeserializeObject<Dictionary<String, Object>>(ret["data"].ToString());
                Console.WriteLine("Error:: " + err["message"].ToString());
                throw new HttpRequestExceptions(code, err["message"].ToString(), err);
            }
            else return ret["data"].ToString();
        }
    }
}
