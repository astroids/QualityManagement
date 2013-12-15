create proc SPgetDokumanDagitmPers
@did int
as
begin
 select p.P_id as 'Personel ID',p.P_Adi + ' ' + p.P_Soyadi as 'Personel', dep.DPT_adi as 'Departmanı' , p.P_Pozisyon as 'Pozisyonu'
from Tbl_Personel p join Tbl_Dokuman_Dagitim d on p.P_id= d.DKMD_personel
		 join Tbl_Departman dep on p.P_Dept= dep.DPT_id
where d.DKMD_id=@did
end
go

CREATE proc SPgetGecerlilik
@gid int
as
begin
select d.DKM_Adi as 'dadi', p.P_Adi + ' ' +p.P_Soyadi as 'sorumlu' ,g.DG_Geçerlilik_Sure as 'gecer',g.DG_Geçerlilik_Tur as 'gecerTip' ,g.DG_Arsiv_Sure as 'arsiv',g.DG_Arsiv_Sure_Tur as 'arsivTip', pd.DKMD_Dagitim_Tarihi as 'dtar'

from Tbl_Dokuman d left join Tbl_Dokuman_Gecerlilik g on d.DKM_id=g.DG_id
	 left join Tbl_Personel p on g.DG_Sorumlu_Personel= p.P_id 
	 left join Tbl_Dokuman_Dagitim pd on d.DKM_id = pd.DKMD_id 
	 
where d.DKM_id=@gid
end
go
