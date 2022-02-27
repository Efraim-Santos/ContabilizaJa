using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContabilizaJa.Processamento.CrossCutting
{
    public class ProcessamentoDoArquivo
    {
        public async Task ReadFiles(List<IFormFile> files)
        {
            foreach (var file in files)
            {
                if (file.Length > 0)
                {
                    //if (!file.FileName.Contains(".ofx"))
                    //{
                    //    ViewData["Error"] = $"A Extensão {file.FileName.Split('.')[1]} é invalida, favor carregar arquivo do tipo ofx!";
                    //    return View("Index");
                    //}
                    //var filePath = Path.GetTempFileName();

                    //string newNameFile = $"extrato_{DateTime.Now.ToString("yyyyMMddTHHmmssZ")}.ofx";

                    //string caminhoDestinoArquivo = $"{GetPathRootFiles()}\\ExtratosImportados\\{newNameFile}";

                    //using (var stream = System.IO.File.Create(caminhoDestinoArquivo))
                    //{
                    //    await formFile.CopyToAsync(stream);
                    //}
                }
            }
        }
    }
}
