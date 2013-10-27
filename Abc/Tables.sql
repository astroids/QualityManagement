create table Sirket(
	s_id int primary key not null,
	s_KAdi nvarchar(30) not null,
	s_TicariAdi nvarchar(60) not null,
	s_VergiNo varchar(10),
	--	check(s_VergiNo like '[0-9],[0-9],[0-9],[0-9],[0-9],[0-9],[0-9],[0-9],[0-9],[0-9]'),
	s_Adres nvarchar(90) not null,
	s_Tel varchar(10),
)


create table Personel(
	p_id int primary key not null,
	p_Adi nvarchar(30) not null,
	p_TcKimlikno varchar(11),
	p_Tell varchar(10),
	p_Tell2 varchar(10),
	p_Email nvarchar(50),
	p_Cinsiyet varchar(1) 
		constraint p_Cinsiyet check(p_Cinsiyet in ('E','K')),
	p_Pozisyon nvarchar(20) not null,
	p_Departman nvarchar(40),
	p_SirketID int not null,
	p_Aday bit,
)

create table IzinTur(
	it_id int primary key not null,
	it_Adi nvarchar(20),

)


create table PersonelIzin(
	--pi_id int primary key not nu
	pi_Persid int 
		foreign key references Personel(p_id) not null,
	pi_Izintur int 
		foreign key references Izintur(it_id) not null,
	pi_BasTarih date not null,
	pi_Sure int,
	pi_OnayVeren int
		foreign key references Personel(p_id) not null,
)

create table PersonelGirisCikis(
	--pgc_id int primary key not null, 
	pgc_Persid int
		foreign key references Personel(p_id) not null,
	pgc_Tarih date not null,
	pgc_Saat time not null,
	--pgc..
)

create table PersoneCV(
	pcv_Pid int primary key not null,
	pcv_id int 
		foreign key references Personel(p_id) not null,
	pcv_Okul nvarchar(80) not null,
	pcv_Hobi nvarchar(80),
	pcv_Sertifika nvarchar(80),
	pcv_Iletisim nvarchar(80),
)
create table Egitim(
	e_id int primary key not null,
	e_Adi nvarchar(50) not null,
	e_Icerik nvarchar(80),
	e_Everen nvarchar(50) not null,
	e_BasTarih date,
	e_BitTarih date,
)

create table PersonelEgitim(
	pe_id int primary key not null,
	pe_Egitimid int 
		foreign key references Egitim(e_id) not null,
	pe_KatilimPers nvarchar(30),
)

insert into Sirket values (
	10001,
	'ACD Bilisim',
	'ACD Bilisim Islem Bilgisayar Yazilim Hiz. San.veTic.Ltd.Sti',
	'1234567891',
	'Organize Sanayi Bolgesi Teknoloji Bulvari TeknoparkPiramit1',
	'2222362010'
)
			
insert into Personel values(
	3,
	'mali vveli',
	'55555555555',
	'6666666666',
	'2222222222',
	'fsdf@gasd.com',
	'E',
	'isci',
	'dagidim',
	10001,
	0
)