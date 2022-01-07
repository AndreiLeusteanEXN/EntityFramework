CREATE TABLE Roles (
	Id									int identity(1, 1) not null,
	Name								nvarchar(50) not null
	CONSTRAINT PK_Role PRIMARY KEY(Id)
);

CREATE TABLE Users (
	Id									int identity(1, 1) not null,
	FirstName							nvarchar(200) not null,
	LastName							nvarchar(200) not null,
	email								nvarchar(200) not null,
	phone								varchar(20),
	isDeleted							bit DEFAULT 0,
	isBanned							bit DEFAULT 0,
	RoleId								int not null,
	CONSTRAINT PK_User PRIMARY KEY(Id),
	CONSTRAINT FK_Roles FOREIGN KEY(RoleId)
		REFERENCES Roles(Id)
);


CREATE TABLE Countries (
	Id									int identity(1, 1) not null,
	Name								nvarchar(100) not null,
	CONSTRAINT PK_Country PRIMARY KEY(Id)
);


CREATE TABLE Cities (
	Id									int identity(1, 1) not null,
	Name								nvarchar(100) not null,
	CountryId							int not null,
	CONSTRAINT PK_City PRIMARY KEY (Id),
	CONSTRAINT FK_Countries FOREIGN KEY (CountryId)
		REFERENCES Countries(Id)
);


CREATE TABLE PropertyTypes (
	Id									int identity(1, 1) not null,
	Type								nvarchar(50) not null,
	CONSTRAINT PK_PropertyType PRIMARY KEY(id)
);


CREATE TABLE Properties (
	Id									int identity(1, 1) not null,
	Name								nvarchar(250) not null,
	Rating								decimal(2, 1) not null,
	Description							nvarchar(MAX) not null,
	Address								nvarchar(MAX) not null,
	Phone								varchar(20) not null,
	TotalRooms							int not null,
	NumberOfDayForRefunds				int not null,
	CityId								int not null,
	AdministratorId						int not null,
	PropertyTypeId						int not null,
	CONSTRAINT PK_Property PRIMARY KEY(Id),
	CONSTRAINT FK_Cities FOREIGN KEY(CityId) 
		REFERENCES Cities(Id),
	CONSTRAINT FK_Admin FOREIGN KEY(AdministratorId) 
		REFERENCES Users(Id),
	CONSTRAINT FK_PropertyType FOREIGN KEY(PropertyTypeId) 
		REFERENCES PropertyTypes(Id)
);


CREATE TABLE PropertyImages (
	Id									int identity(1, 1) not null,
	ImageUrl							nvarchar(2500) not null,
	PropertyId							int not null,
	CONSTRAINT PK_PropertyImage PRIMARY KEY(Id),
	CONSTRAINT FK_Property FOREIGN KEY (PropertyId) 
		REFERENCES Properties(Id)
);


CREATE TABLE Reviews (
	UserId								int not null,
	PropertyId							int not null,
	Description							nvarchar(200),
	Rating								int not null,
	ReviewDate							Date not null,
	CONSTRAINT PK_Review PRIMARY KEY(UserId, PropertyId),
	CONSTRAINT FK_Reviewer FOREIGN KEY(UserId)
		REFERENCES Users(id),
	CONSTRAINT FK_ReviewedProperty FOREIGN KEY(PropertyId)
		REFERENCES Properties(Id)
);


CREATE TABLE GeneralFeatures (
	Id									int identity(1, 1) not null,
	Name								varchar(250) not null,
	IconUrl								varchar(2500) not null,
	CONSTRAINT PK_GeneralFeature PRIMARY KEY(Id)
);


CREATE TABLE PropertyFacilities (
	PropertyId							int not null,
	FeatureId							int not null,
	CONSTRAINT PK_PropertyFacility PRIMARY KEY(PropertyId, FeatureId),
	CONSTRAINT FK_FacilityOfProperty FOREIGN KEY(PropertyId)
		REFERENCES Properties(Id),
	CONSTRAINT FK_PropertyFeature FOREIGN KEY(FeatureId)
		REFERENCES GeneralFeatures(Id)

);


CREATE TABLE RoomCategories (
	Id									int identity(1, 1) not null,
	Name								varchar(100) not null,
	BedsCount							int not null,
	Description							nvarchar(500),
	Price								decimal(20,2) not null,
	CONSTRAINT PK_RoomCategory PRIMARY KEY(Id)
);


--PK_Room could be CategoryId + PropertyId, but in reverse order
CREATE TABLE Rooms (
	Id									int identity(1, 1) not null,
	RoomCategory						int not null,
	PropertyId							int not null,
	CONSTRAINT PK_Room PRIMARY KEY(Id),
	CONSTRAINT FK_RoomCategory FOREIGN KEY(RoomCategory)
		REFERENCES RoomCategories(Id),
	CONSTRAINT FK_RoomOfProperty FOREIGN KEY (PropertyId)
		REFERENCES Properties(Id)
);


CREATE TABLE RoomFeatures (
	Id									int identity(1, 1) not null,
	Name								varchar(250) not null,
	IconUrl								varchar(2500) not null,
	CONSTRAINT PK_RoomFeature PRIMARY KEY(Id)
);


CREATE TABLE RoomFacilities (
	RoomId								int not null,
	FeatureId							int not null,
	CONSTRAINT PK_RoomFacility PRIMARY KEY(RoomId, FeatureId),
	CONSTRAINT FK_FacilityOfRoom FOREIGN KEY(RoomId)
		REFERENCES Rooms(Id),
	CONSTRAINT FK_RoomFeature FOREIGN KEY(FeatureId)
		REFERENCES RoomFeatures(Id)
);


CREATE TABLE Reservations (
	Id									int identity(1, 1) not null,
	CheckInDate							Date not null,
	CheckOutDate						Date not null,
	CancelDate							Date DEFAULT NULL,
	Price								decimal(20, 2) not null,
	PaymentMethod						varchar(20) not null,
	PaymentStatus						bit not null,
	UserId								int not null,
	CONSTRAINT PK_Reservation PRIMARY KEY(Id),
	CONSTRAINT FK_Client FOREIGN KEY(UserId)
		REFERENCES Users(id)
);


CREATE TABLE RoomReservations (
	Id									int identity(1, 1) not null,
	RoomId								int not null,
	ReservationId						int not null,
	CONSTRAINT PK_RoomReservation PRIMARY KEY(Id),
	CONSTRAINT FK_ReservedRoom FOREIGN KEY(RoomId)
		REFERENCES Rooms(Id),
	CONSTRAINT FK_Reservation FOREIGN KEY(ReservationId)
		REFERENCES Reservations(Id)
);