SELECT        dbo.Usterki.opis, dbo.Usterki.stan, dbo.Budynki.adres_budynku, dbo.Mieszkania.numer, dbo.Usterki.id_usterki, dbo.Mieszkania.id_mieszkania, 
                         dbo.Budynki.id_budynku
FROM            dbo.StanyUsterek INNER JOIN
                         dbo.Usterki ON dbo.StanyUsterek.stan = dbo.Usterki.stan INNER JOIN
                         dbo.Mieszkania ON dbo.Usterki.id_mieszkania = dbo.Mieszkania.id_mieszkania INNER JOIN
                         dbo.Budynki ON dbo.Mieszkania.id_budynku = dbo.Budynki.id_budynku