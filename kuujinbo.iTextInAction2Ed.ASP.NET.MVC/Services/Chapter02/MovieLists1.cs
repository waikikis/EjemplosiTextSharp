/*
 * This class is part of the book "iText in Action - 2nd Edition"
 * written by Bruno Lowagie (ISBN: 9781935182610)
 * For more info, go to: http://itextpdf.com/examples/
 * This example only works with the AGPL version of iText.
 */
using System;
using System.IO;
using System.Data.Common;
using iTextSharp.text;
using iTextSharp.text.pdf;
using kuujinbo.iTextInAction2Ed.ASP.NET.MVC.Services.Intro_1_2;

namespace kuujinbo.iTextInAction2Ed.ASP.NET.MVC.Services.Chapter02
{
    public class MovieLists1 : IWriter
    {
        // ===========================================================================
        public void Write(Stream stream)
        {
            // step 1
            using (Document document = new Document())
            {
                // step 2
                PdfWriter.GetInstance(document, stream);
                // step 3
                document.Open();
                // step 4
                var SQL =
        @"SELECT DISTINCT mc.country_id, c.country, count(*) AS c
FROM film_country c, film_movie_country mc
WHERE c.id = mc.country_id
GROUP BY mc.country_id, country ORDER BY c DESC";
                // Create a new list
                List list = new List(List.ORDERED);
                // loop over the countries
                using (var c = AdoDB.Provider.CreateConnection())
                {
                    c.ConnectionString = AdoDB.CS;
                    using (DbCommand cmd = c.CreateCommand())
                    {
                        cmd.CommandText = SQL;
                        c.Open();
                        using (var r = cmd.ExecuteReader())
                        {
                            while (r.Read())
                            {
                                // create a list item for the country
                                ListItem item = new ListItem(
                                  string.Format("{0}: {1} movies",
                                    r["country"].ToString(), r["c"].ToString()
                                  ),
                                  FilmFonts.BOLDITALIC
                                );
                                // create a movie list for each country
                                List movielist = new List(List.ORDERED, List.ALPHABETICAL);
                                movielist.Lowercase = List.LOWERCASE;
                                foreach (Movie movie in
                                    PojoFactory.GetMovies(r["country_id"].ToString())
                                )
                                {
                                    ListItem movieitem = new ListItem(movie.MovieTitle);
                                    List directorlist = new List(List.UNORDERED);
                                    foreach (Director director in movie.Directors)
                                    {
                                        directorlist.Add(String.Format("{0}, {1}",
                                          director.Name, director.GivenName
                                        ));
                                    }
                                    movieitem.Add(directorlist);
                                    movielist.Add(movieitem);
                                }
                                item.Add(movielist);
                                list.Add(item);
                            }
                            document.Add(list);
                        }
                    }
                }
            }
        }
        // ===========================================================================
    }
}