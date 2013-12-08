
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




