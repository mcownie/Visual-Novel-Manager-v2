using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using VisualNovelManagerCore.Database.Model.VNDB.VnInfo;
using VndbSharp.Models;
using VndbSharp.Models.Common;
using VndbSharp.Models.VisualNovel;
using LiteDB;

namespace VisualNovelManagerCore.Controls.Vndb.AddVn
{
    class AddDataToDb
    {
        private void AddToDb()
        {

        }

        private async Task AddVnInfo(VndbResponse<VisualNovel> visualNovels)
        {
            if (visualNovels.FirstOrDefault() != null)
            {
                VisualNovel visualNovel = visualNovels.FirstOrDefault();

                VnInfo dbInfo = new VnInfo()
                {
                    VnId = visualNovel.Id,
                    Title = visualNovel.Name,
                    Original = visualNovel.OriginalName,
                    Released = visualNovel.Released?.ToString() ?? null,
                    Languages = ConvertToCsv(visualNovel.Languages),
                    OriginalLanguages = ConvertToCsv(visualNovel.OriginalLanguages),
                    Platforms = ConvertToCsv(visualNovel.Platforms),
                    Aliases = ConvertToCsv(visualNovel.Aliases),
                    Length = visualNovel.Length?.ToString(),
                    Description = visualNovel.Description,
                    ImageLink = visualNovel.Image,
                    ImageNsfw = visualNovel.IsImageNsfw,
                    Popularity = visualNovel.Popularity,
                    Rating = visualNovel.Rating
                };

                
            }
        }

        private string ConvertBirthday(SimpleDate birthday)
        {
            string formatted = string.Empty;
            if (birthday == null) return formatted;
            if (birthday.Month == null) return birthday.Month == null ? birthday.Day.ToString() : string.Empty;
            string month = System.Globalization.DateTimeFormatInfo.InvariantInfo.GetMonthName(Convert.ToInt32(birthday.Month));
            formatted = $"{month} {birthday.Day}";
            return formatted;
        }

        string ConvertToCsv(ReadOnlyCollection<string> input)
        {
            return input != null ? string.Join(",", input) : null;
        }
    }
}
