
--departman
create procedure SPgenelDeprtman 
as
begin
select d3.DPT_id as 'Dep ID' ,d3.DPT_adi as 'Departman Adi',depa.[Personel Sayisi],bas.P_Adi +' '+ bas.P_Soyadi as 'Departman Baskani Adi'
 from(
	(select count (d.DPT_id)as 'Personel Sayisi',d.DPT_id
	from Tbl_Departman d 
		left join
		Tbl_Personel p 
		on d.DPT_id = p.P_Dept
		where p.P_Silindi =0
		group by d.DPT_id
		) as depa
		join Tbl_Departman d3 on depa.DPT_id= d3.DPT_id 

		join

	(select * from Tbl_Departman d2 left join Tbl_Personel p2 on d2.DPT_baskani=p2.P_id ) as bas
		on depa.DPT_id=bas .DPT_id
)
end

--doküman listesi listele id ise
create proc SPgetDokumanByID
@id int
as
begin
select d.DKM_id as 'Doküman ID', d.DKM_Adi as 'Doküman Adı',d.DKM_Baslik as 'Doküman Başlığı',t.DKMT_Adi as 'Doküman Tipi'  from Tbl_Dokuman d join  Tbl_Dokuman_Tipi t on d.DKM_Tip=t.DKMT_id where d.DKM_Ilgili_Departman=@id
end


--doküman listesi listele nullsa
create proc SPgetAllDok
as
begin
select d.DKM_id as 'Doküman ID', d.DKM_Adi as 'Doküman Adı',d.DKM_Baslik as 'Doküman Başlığı',t.DKMT_Adi as 'Doküman Tipi'  from Tbl_Dokuman d join  Tbl_Dokuman_Tipi t on d.DKM_Tip=t.DKMT_id 
end



--dokumanIncele fill()
create proc SPgetDocIDincele
@did int
as
begin
select d.DKM_id as 'id',d.DKM_Adi as 'dadı',d.DKM_Revizyon_Tar as 'rev',d.DKM_Aciklama as 'açık',d.DKM_Baslik as 'baslik',d.DKM_Icerik as 'icer',t.DKMT_Adi as 'dtip',d.DKM_Revizyon_Tar as 'tar',p.P_Adi as 'hazper',p.P_Soyadi as 'hazsoy',p2.P_Adi as 'oper',p2.P_Soyadi as 'osoy',de.DPT_adi as 'ddep',de2.DPT_adi as 'hdep',de3.DPT_adi as 'odep',p.P_Pozisyon as 'hpoz',p2.P_Pozisyon as 'opoz'
 from (((((Tbl_Dokuman d join  Tbl_Dokuman_Tipi t on d.DKM_Tip=t.DKMT_id)
		join Tbl_Personel p on d.DKM_Hazirlayan_Personel=p.P_id)
		left join Tbl_Personel p2 on d.DKM_Onaylayan_Personel=p2.P_id) 
		join Tbl_Departman de on d.DKM_Ilgili_Departman= de.DPT_id )
		join Tbl_Departman de2 on p.P_Dept= de2.DPT_id) 
		left join Tbl_Departman de3 on p2.P_Dept = de3.DPT_id 
			where d.DKM_Child is NULL and d.DKM_id =@did
end

--personel Departman Rapor queryselection()
create proc SPgetDepartmanPersonelRapor
@dep int
as
begin
select p.P_id as 'Personel ID',p.P_Adi as 'Personel Adi',p.P_Soyadi as 'Soyadı',p.P_Pozisyon as 'Pozisyonu',p.P_Email as 'E-Mail',p.P_Tel1 as 'Telefon',p.P_D_Tar as 'Doğum Tarihi',p.P_D_Yer as 'Doğum Yeri',p.P_Med_Hal as 'Medeni Durumu' 
 from Tbl_Personel p join Tbl_Departman d 
		 on p.P_Dept = d.DPT_id 
		 where P_Silindi = 0  and p.P_Aday=0 and p.P_Dept =@dep
end

--personel Raporu Toplu   queryselection()		//tum personel
create proc SPgetTumPersonelRapor
as
begin
select p.P_id as 'Personel ID',p.P_Adi as 'Personel Adi',p.P_Soyadi as 'Soyadı',d.DPT_adi as 'Departmanı',p.P_Pozisyon as 'Pozisyonu',p.P_Email as 'E-Mail',p.P_Tel1 as 'Telefon',p.P_D_Yer as 'Doğum Yeri',p.P_Med_Hal as 'Medeni Durumu' 
	from Tbl_Personel p join Tbl_Departman d
			on p.P_Dept = d.DPT_id 
			where P_Silindi = 0
end

--personel Raporu Toplu   queryselection()		//kadrolu personel
create proc SPgetTumKadroluPersonelRapor
as
begin
select p.P_id as 'Personel ID',p.P_Adi as 'Personel Adi',p.P_Soyadi as 'Soyadı',d.DPT_adi as 'Departmanı',p.P_Pozisyon as 'Pozisyonu',p.P_Email as 'E-Mail',p.P_Tel1 as 'Telefon',p.P_D_Yer as 'Doğum Yeri',p.P_Med_Hal as 'Medeni Durumu'
  from Tbl_Personel p join Tbl_Departman d
	on p.P_Dept = d.DPT_id
	where P_Silindi = 0  and p.P_Aday=0 
end

--personel Raporu Toplu   queryselection()		//stajyer aday
create proc SPgetAdayPersonelRapor
as
begin
select p.P_id as 'Personel ID',p.P_Adi as 'Personel Adi',p.P_Soyadi as 'Soyadı',d.DPT_adi as 'Departmanı',p.P_Pozisyon as 'Pozisyonu',p.P_Email as 'E-Mail',p.P_Tel1 as 'Telefon',p.P_D_Yer as 'Doğum Yeri',p.P_Med_Hal as 'Medeni Durumu'
  from Tbl_Personel p join Tbl_Departman d
	on p.P_Dept = d.DPT_id
	where P_Silindi = 0  and p.P_Aday=0 
end


--personelEkleSil listele()  -- null  calışan
create proc SPgetPersonel 
as
begin
select p.P_id as 'Personel ID',p.P_Adi as 'Personel Adi',p.P_Soyadi as 'Soyadı',d.DPT_adi as 'Departmanı',p.P_Pozisyon as 'Pozisyonu',p.P_Email as 'E-Mail',p.P_Tel1 as 'Telefon',p.P_Aday as 'Aday Durumu'
from Tbl_Personel p join Tbl_Departman d on p.P_Dept = d.DPT_id 
where P_Silindi = 0
end

--personelEkleSil listele()  -- null  calışan
create proc SPgetPersonel 
as
begin
select p.P_id as 'Personel ID',p.P_Adi as 'Personel Adi',p.P_Soyadi as 'Soyadı',d.DPT_adi as 'Departmanı',p.P_Pozisyon as 'Pozisyonu',p.P_Email as 'E-Mail',p.P_Tel1 as 'Telefon',p.P_Aday as 'Aday Durumu'
from Tbl_Personel p join Tbl_Departman d on p.P_Dept = d.DPT_id 
where P_Silindi = 0
end

--personelEkleSil listele()  --null tum egitim
create proc SPgetTumEgitim
as
begin
select E_id as 'id', e.E_Adi as 'Egitim Adı',e.E_BasTarih as 'Başlangış tarihi', e.E_BitTarih as 'Bitiş Tarihi',p.P_Adi as 'Egitim Veren',p.P_Soyadi as 'soyadı'
 from Tbl_Egitim e join Tbl_Personel p on  e.E_Egi_Veren=p.P_id
 end


 --personelEkleSil listele()  --tun isten ayrılan personel
 create proc SPgetSilinen
 as
 begin
 Select * From Tbl_Personel where P_Silindi=1
 end


 /*
 select E_id as 'id', e.E_Adi as 'Egitim Adı',e.E_BasTarih as 'Başlangış tarihi', e.E_BitTarih as 'Bitiş Tarihi',p.P_Adi as 'Egitim Veren',p.P_Soyadi as 'soyadı' 
 from Tbl_Egitim e, Tbl_Personel p where e.E_Egi_Veren=p.P_id
 */


 --personelEkleSil izindeolanlar_Click_1()  --su anda izinde olanlar  
 --datetime date e donuscek															---tablo  degismesi gerekli
 create proc SPgetIzindeOlanlar
@Ctime datetime
 as 
 begin
 select p.P_Adi , p.P_id,i.PI_BasTarih,i.PI_BasTarih,t.IT_adi
	from Tbl_Personel_Izin i, Tbl_Personel p,Tbl_Izin_Tur t 
	where (@CTime between  i.PI_BasTarih and i.PI_BitTarih ) and p.P_id= i.PI_Pers_id and t.IT_id= i.PI_Izin_Tur and not i.PI_Onay is null;
end

/*
--personelEkleSil izingecmisi_Click  --id izin gecmisi							-- left join
 create proc SPgetIzinGecmisi
@sid int
as
begin
Select pe.P_id as 'Sicil No', pe.P_Adi as 'Adı', pe.P_Soyadi as 'Soyadı', PI_BasTarih as 'Başlangıç Tarihi',iz.PI_BitTarih 'Bitiş Tarihi',t.IT_adi as 'İzin Türü' ,iz.PI_Onay as 'Onay durumu',p2.P_Adi as 'Onay Veren Adi',p2.P_Soyadi as 'Onay Veren Soyadı' 
From Tbl_Personel_Izin iz, Tbl_Personel pe ,Tbl_Personel p2,Tbl_Izin_Tur t 
where pe.P_id =iz.PI_Pers_id and  iz.PI_Pers_id=@sid and p2.P_id=iz.PI_OnayVeren_id and t.IT_id = iz.PI_Izin_Tur;
end
*/
--personelEkleSil onaybekliyenler_Click()  --izin onayı bekleyen personel
create proc SPgetIzinOnayListele
as
begin
select p.P_Adi , p.P_id,i.PI_BasTarih,i.PI_BasTarih,t.IT_adi
from Tbl_Personel p , Tbl_Personel_Izin i ,Tbl_Izin_Tur t
where p.P_id=i.PI_id and i.PI_Izin_Tur=t.IT_id and i.PI_Onay is null
end


--personelEkleSil onayla_Click()  -- izin onaylama yetik gerekiyo
create proc SPizinOnayla
@sid int,
@OverID int
as 
begin
update Tbl_Personel_Izin set PI_Onay=1,PI_OnayVeren_id =@OverID 
where PI_id = @sid
end

--personelEkleSil izingecmisi_Click_1   --personel izin geçmişi						///izin veren eklencek
create proc SPizinGecmisi
@ID int
as
begin
Select pe.P_id as 'Sicil No', pe.P_Adi as 'Adı', pe.P_Soyadi as 'soyadı', PI_BasTarih as 'Başlangıç Tarihi',iz.PI_BitTarih 'Bitiş Tarihi',iz.PI_Onay as 'Onay durumu' ,yon.P_Adi + ' ' + yon.P_Soyadi as 'Onay Veren'
From Tbl_Personel_Izin iz join Tbl_Personel pe 
	on iz.PI_Pers_id=pe.P_id 
	left join Tbl_Personel yon on iz.PI_OnayVeren_id=yon.P_id
	where pe.P_id = @ID
end



--personelEkleSil onaybekliyenler_Click_1  izin onayı bekleyen personel
create proc SPizinOnayiBekleyenPersonel
as
begin
select pe.P_id as 'Sicil No', pe.P_Adi as 'Adı', pe.P_Soyadi as 'soyadı',iz.PI_id as 'İzin No' , PI_BasTarih as 'Başlangıç Tarihi',iz.PI_BitTarih 'Bitiş Tarihi',t.IT_adi as 'İzin Türü' 
from Tbl_Personel_Izin iz , Tbl_Personel pe,Tbl_Izin_Tur t 
where iz.PI_Pers_id=pe.P_id and iz.PI_Onay is NULL and iz.PI_Izin_Tur=t.IT_id
end


--personelEkleSil silme_Click  personel isten çıkarma
create proc SPistenCikarma
@P_id int
as
begin
update Tbl_Personel set P_Silindi='1' where P_id = @P_id
end