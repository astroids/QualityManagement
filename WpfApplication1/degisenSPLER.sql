USE [Personel]
GO
/****** Object:  StoredProcedure [dbo].[SPgetAllDok]    Script Date: 10/12/2013 14:05:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER proc [dbo].[SPgetAllDok]
as
begin
select d.DKM_id as 'Doküman ID', d.DKM_Adi as 'Doküman Adı',d.DKM_Baslik as 'Doküman Başlığı',t.DKMT_Adi as 'Doküman Tipi' 
 from Tbl_Dokuman d join  Tbl_Dokuman_Tipi t on d.DKM_Tip=t.DKMT_id
 where d.DKM_Child is NULL
end

GO
/****** Object:  StoredProcedure [dbo].[SPgetDocIDincele]    Script Date: 10/12/2013 14:05:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER proc [dbo].[SPgetDocIDincele]
@did int
as
begin
select d.DKM_id as 'id',d.DKM_Adi as 'dadı',d.DKM_Revizyon_Tar as 'rev',d.DKM_Child as 'child',d.DKM_Parent as 'parent',d.DKM_Aciklama as 'açık',d.DKM_Baslik as 'baslik',d.DKM_Icerik as 'icer',t.DKMT_Adi as 'dtip',d.DKM_Revizyon_Tar as 'tar',p.P_Adi+' '+p.P_Soyadi  as 'hazper',p2.P_Adi+' '+p2.P_Soyadi as 'oper',de.DPT_adi as 'ddep',de2.DPT_adi as 'hdep',de3.DPT_adi as 'odep',p.P_Pozisyon as 'hpoz',p2.P_Pozisyon as 'opoz'
	from (((((Tbl_Dokuman d join  Tbl_Dokuman_Tipi t on d.DKM_Tip=t.DKMT_id)
		join Tbl_Personel p on d.DKM_Hazirlayan_Personel=p.P_id)
		left join Tbl_Personel p2 on d.DKM_Onaylayan_Personel=p2.P_id) 
		join Tbl_Departman de on d.DKM_Ilgili_Departman= de.DPT_id )
		join Tbl_Departman de2 on p.P_Dept= de2.DPT_id) 
		left join Tbl_Departman de3 on p2.P_Dept = de3.DPT_id 
   where d.DKM_id=@did
end

GO
/****** Object:  StoredProcedure [dbo].[SPgetDokumanByID]    Script Date: 10/12/2013 14:06:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER proc [dbo].[SPgetDokumanByID]
@id int
as
begin
select d.DKM_id as 'Doküman ID', d.DKM_Adi as 'Doküman Adı',d.DKM_Baslik as 'Doküman Başlığı',t.DKMT_Adi as 'Doküman Tipi' 
from Tbl_Dokuman d join  Tbl_Dokuman_Tipi t on d.DKM_Tip=t.DKMT_id where d.DKM_Ilgili_Departman=@id and d.DKM_Child is NULL
end