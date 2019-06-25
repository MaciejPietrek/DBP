SELECT        dbo.Najemcy.imie, dbo.Najemcy.nazwisko, dbo.Mieszkania.numer, dbo.Budynki.adres_budynku, dbo.Wynajmy.data_rozpoczecia, dbo.Wynajmy.data_zakonczenia, 
                         dbo.Najemcy.id_najemcy, dbo.Budynki.id_budynku, dbo.Mieszkania.id_mieszkania, dbo.Wynajmy.id_wynajmu, dbo.Wynajmy.cena_miesieczna
FROM            dbo.Budynki INNER JOIN
                         dbo.Mieszkania ON dbo.Budynki.id_budynku = dbo.Mieszkania.id_budynku INNER JOIN
                         dbo.Wynajmy ON dbo.Mieszkania.id_mieszkania = dbo.Wynajmy.id_mieszkania INNER JOIN
                         dbo.Najemcy ON dbo.Wynajmy.id_najemcy = dbo.Najemcy.id_najemcy