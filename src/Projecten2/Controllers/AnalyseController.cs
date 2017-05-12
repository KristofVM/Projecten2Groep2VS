using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Net.Http.Headers;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using Org.BouncyCastle.Crypto.Parameters;
using Projecten2.Models.Domain;
using Projecten2.Models.ViewModels;
using Projecten2.Models.ViewModels.BatenViewModels;

namespace Projecten2.Controllers
{
    public class AnalyseController : Controller
    {
        private readonly IAnalyseRepository _analyseRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHostingEnvironment _hostingEnvironment;

        public AnalyseController(
            IAnalyseRepository analyseRepository,
            UserManager<ApplicationUser> userManager,
            IHostingEnvironment hostingEnvironment)
        {
            _userManager = userManager;
            _analyseRepository = analyseRepository;
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Edit(int id)
        {
            Analyse analyse = _analyseRepository.GetById(id);
            return View(new EditViewModel(analyse));
        }

        [HttpPost]
        public IActionResult Edit(EditViewModel editViewModel)
        {
            if (ModelState.IsValid)
            {
                Analyse analyse = null;
                try
                {
                    analyse = _analyseRepository.GetById(editViewModel.AnalyseId);
                    MapEditViewModelToAnalyse(editViewModel, analyse);
                    _analyseRepository.SaveChanges();
                    TempData["message"] = $"You successfully updated brewer {analyse.Bedrijf}.";
                }
                catch
                {
                    TempData["error"] = $"Sorry, something went wrong, brewer {analyse?.Bedrijf} was not updated...";
                }
                return RedirectToAction(nameof(Index), "Home");
            }
            else
            {
                return View(editViewModel);
            }
        }

        public IActionResult Create()
        {
            return View(nameof(Edit), new EditViewModel(new Analyse()));
        }

        [HttpPost]
        public IActionResult Create(EditViewModel editViewModel)
        {
            if (ModelState.IsValid)
            {
                Analyse analyse = new Analyse();
                try
                {
                    MapEditViewModelToAnalyse(editViewModel, analyse);
                    _analyseRepository.Add(analyse);
                    _analyseRepository.SaveChanges();
                    TempData["message"] = $"You successfully added brewer {analyse.Bedrijf}.";
                }
                catch
                {
                    TempData["error"] = "Sorry, something went wrong, the analyse was not added...";
                }
                return RedirectToAction(nameof(Index), "Home");
            }
            else
            {
                return View(nameof(Edit),editViewModel);
            }
        }

        public IActionResult KostenBaten(int id)
        {
            Analyse analyse = _analyseRepository.GetById(id);
            return View(analyse);
        }

        public IActionResult BVraag(int AnalyseId, int VraagId)
        {
            switch (VraagId)
            {
                case 2: return RedirectToAction("BVraagDouble", "Vragen", new { AnalyseId, VraagId });
                case 3: return RedirectToAction("BVraagS3Overzicht", "Overzichten", new { AnalyseId });
                case 4: return RedirectToAction("BVraagS4Overzicht", "Overzichten", new { AnalyseId });
                case 5: return RedirectToAction("BVraagS5Overzicht", "Overzichten", new { AnalyseId });
                //case 6: return RedirectToAction("BVraagInt", "Vragen", new { AnalyseId }); break;
                case 6: return RedirectToAction("BVraag6", "Vragen", new { AnalyseId }); break;
                case 7: return RedirectToAction("BVraagDouble", "Vragen", new { AnalyseId, VraagId });
                case 8: return RedirectToAction("BVraagDouble", "Vragen", new { AnalyseId, VraagId });
                case 9: return RedirectToAction("BVraagS9Overzicht", "Overzichten", new { AnalyseId });
                //case 101: return RedirectToAction("BVraagDouble", "Vragen", new { AnalyseId, VraagId }); break;
                //case 102: return RedirectToAction("BVraagDouble", "Vragen", new { AnalyseId, VraagId }); break;
                case 10: return RedirectToAction("BVraag10", "Vragen", new { AnalyseId, VraagId });
                case 11: return RedirectToAction("BVraagS11Overzicht", "Overzichten", new { AnalyseId });
                default: return NotFound();
            }
        }
        public IActionResult KVraag(int AnalyseId, int VraagId)
        {
            switch (VraagId)
            {
                //case 1: return RedirectToAction("KVraagS1", "Vragen", new { AnalyseId }); break;
                case 1: return RedirectToAction("KVraagS1Overzicht", "Overzichten", new { AnalyseId });
                //case 11: return RedirectToAction("KVraagS2", "Vragen", new { AnalyseId }); break;
                case 2: return RedirectToAction("KVraagS2Overzicht", "Overzichten", new { AnalyseId });
                case 3: return RedirectToAction("KVraagS3Overzicht", "Overzichten", new { AnalyseId });
                case 4: return RedirectToAction("KVraagS4Overzicht", "Overzichten", new { AnalyseId });
                case 5: return RedirectToAction("KVraagS5Overzicht", "Overzichten", new { AnalyseId });
                case 6: return RedirectToAction("KVraagS6Overzicht", "Overzichten", new { AnalyseId });
                case 7: return RedirectToAction("KVraagS7Overzicht", "Overzichten", new { AnalyseId });
                default: return NotFound();
            }
        }

        [HttpGet]
        [Route("Export")]
        public IActionResult Export(int id)
        {
            Analyse analyse = _analyseRepository.GetById(id);
            string sWebRootFolder = _hostingEnvironment.WebRootPath;
            string sFileName = @"analyse.xlsx";
            FileInfo file = new FileInfo(Path.Combine(sWebRootFolder, sFileName));
            if (file.Exists)
            {
                file.Delete();
                file = new FileInfo(Path.Combine(sWebRootFolder, sFileName));
            }
            using (ExcelPackage package = new ExcelPackage(file))
            {
                // add a new worksheet to the empty workbook
                ExcelWorksheet ws = package.Workbook.Worksheets.Add("kosten-baten");

                var user = _userManager.FindByIdAsync(analyse.ApplicationUserId).Result;

                //Bedrijf
                ws.Cells["A1"].Value = user.Voornaam + " " + user.Naam + " - " + user.Email;
                ws.Cells["A2"].Value = "Bedrijf: " + analyse.Bedrijf;
                ws.Cells["A3"].Value = "Afdeling: " + analyse.Afdeling;

                //Baten
                ws.Cells["A4:B4"].Merge = true;
                ws.Cells["A4:B4"].Value = "Baten";

                //Vraag1
                ws.Cells["A5"].Value = "Totale loonkostsubsidies (VOP, IBO en doelgroepvermindering)";
                ws.Cells["B5"].Value = "€ " + analyse.getBVragenFormat(1);

                //Vraag2
                ws.Cells["A6"].Value = "tegemoetkoming in de kosten voor aanpassingen werkomgeving/aangepast gereedschap";
                ws.Cells["B6"].Value = "€ " + analyse.getBVragenFormat(2);

                //Vraag3
                ws.Cells["A7"].Value = "besparing reguliere medew. op hetzelfde niveau";
                ws.Cells["B7"].Value = "€ " + analyse.getBVragenFormat(3);

                //Vraag4
                ws.Cells["A8"].Value = "besparing reguliere medew. op hoger niveau";
                ws.Cells["B8"].Value = "€ " + analyse.getBVragenFormat(4);

                //Vraag5
                ws.Cells["A9"].Value = "besparing (extra) uitzendkrachten";
                ws.Cells["B9"].Value = "€ " + analyse.getBVragenFormat(5);

                //Vraag6
                ws.Cells["A10"].Value = "inperking omzetverlies";
                ws.Cells["B10"].Value = "€ " + analyse.getBVragenFormat(6);

                //Vraag7
                ws.Cells["A11"].Value = "productiviteitswinst";
                ws.Cells["B11"].Value = "€ " + analyse.getBVragenFormat(7);

                //Vraag8
                ws.Cells["A12"].Value = "besparing op overuren";
                ws.Cells["B12"].Value = "€ " + analyse.getBVragenFormat(8);

                //Vraag9
                ws.Cells["A13"].Value = "besparing op outsourcing";
                ws.Cells["B13"].Value = "€ " + analyse.getBVragenFormat(9);

                //Vraag10
                ws.Cells["A14"].Value = "logistieke besparing";
                ws.Cells["B14"].Value = "€ " + analyse.getBVragenFormat(10);

                //Vraag11
                ws.Cells["A15"].Value = "andere besparingen";
                ws.Cells["B15"].Value = "€ " + analyse.getBVragenFormat(11);

                //subtotaal
                ws.Cells["A16"].Value = "Subtotaal baten";
                ws.Cells["B16"].Value = "€ " + analyse.getBatenFormat();

                //Kosten
                ws.Cells["C4:D4"].Merge = true;
                ws.Cells["C4:D4"].Value = "Kosten";
                ws.Cells["C4:D4"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

                //Vraag1
                ws.Cells["D5"].Value = "loonkosten medewerkers met grote afstand tot arbeidsmarkt";
                ws.Cells["C5"].Value = "€ " + analyse.getKVragenFormat(1);

                //Vraag2
                ws.Cells["D6"].Value = "voorbereiding start medewerker met grote afstand tot de arbeidsmarkt";
                ws.Cells["C6"].Value = "€ " + analyse.getKVragenFormat(2);

                //Vraag3
                ws.Cells["D7"].Value = "extra kosten werkkleding e.a. personeelskosten";
                ws.Cells["C7"].Value = "€ " + analyse.getKVragenFormat(3);

                //Vraag4
                ws.Cells["D8"].Value = "extra kosten voor aanpassingen werkomgeving/aangepast gereedschap";
                ws.Cells["C8"].Value = "€ " + analyse.getKVragenFormat(4);

                //Vraag5
                ws.Cells["D9"].Value = "extra kosten opleiding";
                ws.Cells["C9"].Value = "€ " + analyse.getKVragenFormat(5);

                //Vraag6
                ws.Cells["D10"].Value = "extra kosten administratie en begeleiding";
                ws.Cells["C10"].Value = "€ " + analyse.getKVragenFormat(6);

                //Vraag7
                ws.Cells["D11"].Value = "Andere kosten";
                ws.Cells["C11"].Value = "€ " + analyse.getKVragenFormat(7);

                //subtotaal
                ws.Cells["D16"].Value = "Subtotaal baten";
                ws.Cells["C16"].Value = "€ " + analyse.getBatenFormat();

                //SUBTOTAAL
                ws.Cells["B17:C17"].Value = "---SUBTOTAAL---" + "\n" + "€ " + analyse.getBalansFormat();
                ws.Cells["B17:C17"].Merge = true;
                ws.Cells["B17:C17"].Style.Font.Bold = true;
                ws.Cells["B17:C17"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells["B17:C17"].Style.Fill.BackgroundColor.SetColor(Color.Gray);
                ws.Cells["B17:C17"].Style.Border.BorderAround(ExcelBorderStyle.Thin);

                //Maakt collums juiste breedte
                ws.Cells[ws.Dimension.Address].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                ws.Cells["A5:A15"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells["A5:A15"].Style.Fill.BackgroundColor.SetColor(Color.LightGreen);

                ws.Cells["D5:D15"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells["D5:D15"].Style.Fill.BackgroundColor.SetColor(Color.LightCoral);

                ws.Cells["A16:B16"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells["A16:B16"].Style.Fill.BackgroundColor.SetColor(Color.SpringGreen);

                ws.Cells["C16:D16"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells["C16:D16"].Style.Fill.BackgroundColor.SetColor(Color.Crimson);

                ws.Cells["A16:D16"].Style.Font.Bold = true;

                ws.Cells["A4:D4"].Style.Font.Size = 14;
                ws.Cells["A4:D4"].Style.Font.Bold = true;

                ws.Cells["A5:D17"].Style.Font.Size = 10;

                for (int r = 4; r <= 16; r++)
                {
                    for (int c = 1; c <= 4; c++)
                    {
                        ws.Cells[r, c].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                        ws.Cells[r, c].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                        ws.Cells[r, c].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                        ws.Cells[r, c].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    }
                }
                for (int r = 4; r <= 17; r++)
                {
                    ws.Row(r).Height = 30;
                }

                ws.Column(1).Width = 45;
                ws.Column(1).Style.WrapText = true;

                ws.Column(2).Width = 13;

                ws.Column(3).Width = 13;

                ws.Column(4).Width = 45;
                ws.Column(4).Style.WrapText = true;

                package.Save(); //Save the workbook.
            }
            var result = PhysicalFile(Path.Combine(sWebRootFolder, sFileName), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");

            Response.Headers["Content-Disposition"] = new ContentDispositionHeaderValue("attachment")
            {
                FileName = file.Name
            }.ToString();

            return result;
        }

        private void MapEditViewModelToAnalyse(EditViewModel editViewModel, Analyse analyse)
        {
            analyse.ApplicationUserId = _userManager.GetUserId(User);
            analyse.Bedrijf = editViewModel.Bedrijf;
            analyse.Afdeling = editViewModel.Afdeling;
            analyse.PatronaleBijdrage = editViewModel.PatronaleBijdrage;
            analyse.UrenVoltijdsWerkweek = editViewModel.UrenVoltijdsWerkweek;
        }
    }
}