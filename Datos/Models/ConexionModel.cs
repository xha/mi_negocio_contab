using System;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Bson;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;

namespace Datos.Models
{
    public class ConexionModel
    {
        public ConexionModel()
        {
            Server = "fqIsxR4KrrIyc8lLaY3kZl8tqbnCjAgU";
            UsuarioServer = "lSNH6+a86pR0TfDMXvvkcg==";
            ContraseniaServer = "DBf6p69JWgSnta6/hTLdpQ==";
        }

        public string Server { get; set; }
        public string UsuarioServer { get; set; }
        public string ContraseniaServer { get; set; }

        public string Encriptar(string input)
        {
            byte[] iv = ASCIIEncoding.ASCII.GetBytes("qualityi");
            byte[] encryptionKey = Convert.FromBase64String("rpadftlyhorfdertghyujki8765rgyhj");
            byte[] buffer = Encoding.UTF8.GetBytes(input);
            TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
            des.Key = encryptionKey;
            des.IV = iv;
            return Convert.ToBase64String(des.CreateEncryptor().TransformFinalBlock(buffer, 0, buffer.Length));
        }

        public byte[] CreateBinaryData<T>(T TObject)
        {
            if (TObject == null)
                return null;

            byte[] binaryData;
            JsonSerializer serializer = new JsonSerializer();
            using (MemoryStream ms = new MemoryStream())
            {
                using (BsonDataWriter bsonWriter = new BsonDataWriter(ms))
                {
                    serializer.Serialize(bsonWriter, TObject);
                }
                binaryData = ms.ToArray();
            }

            return binaryData;
        }

        

        public string Conexion()
        {
            ConexionModel dt = new ConexionModel();
            //dt.Server           = "fqIsxR4KrrIyc8lLaY3kZl8tqbnCjAgU";  //www.starsoftweb.com
            //dt.UsuarioServer    = "lSNH6+a86pR0TfDMXvvkcg=="; //developer
            //dt.ContraseniaServer= "DBf6p69JWgSnta6/hTLdpQ=="; //minegocio

            byte[] binaryData = CreateBinaryData(dt);
            string b64 = Convert.ToBase64String(binaryData);

            return b64;
        }

        public string ListadoGet(string api) {
            string _CREDENCIALES = Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes("EPISODE:123"));

            HttpClient client = new HttpClient(new HttpClientHandler());
            client.BaseAddress = new Uri("http://www.starsoftweb.com/ServicioMiNegocio/Api/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", _CREDENCIALES);

            var response = client.GetAsync(client.BaseAddress + api + Conexion()).Result;

            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsStringAsync().Result;
            } else
            {
                return "";
            }
        }

        public bool Ejecutar(string ruta, string encabezado, string detalle = null)
        {
            string _CREDENCIALES = Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes("EPISODE:123"));

            HttpClient client = new HttpClient(new HttpClientHandler());
            client.BaseAddress = new Uri("http://www.starsoftweb.com/ServicioMiNegocio/api/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", _CREDENCIALES);
            HttpResponseMessage respuesta = new HttpResponseMessage();

            if (String.IsNullOrEmpty(detalle)) {

            } else { 
                
            }

            JArray ArrayEncabezado = JArray.Parse(encabezado);
            JObject cadena = new JObject();

            foreach (JObject parsedObject in ArrayEncabezado.Children<JObject>())
            {
                foreach (JProperty parsedProperty in parsedObject.Properties())
                {
                    string propertyName = parsedProperty.Name;
                    string propertyValue = (string)parsedProperty.Value;
                    cadena.Add(new JProperty(propertyName, propertyValue));
                }
            }

            cadena.Add(new JProperty("Server", Server));
            cadena.Add(new JProperty("UsuarioServer", UsuarioServer));
            cadena.Add(new JProperty("ContraseniaServer", ContraseniaServer));

            HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(cadena), Encoding.UTF8, "application/json");

            var response = client.PostAsync(client.BaseAddress + ruta, httpContent).Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;

                if (data.Contains("IsSuccess\":true"))
                {
                    return true;
                } else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
