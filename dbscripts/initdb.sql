CREATE TABLE IF NOT EXISTS Person (
  Id serial not NULL PRIMARY KEY,
  Name VARCHAR(255) NOT NULL,
  Document VARCHAR(50) UNIQUE NOT NULL,
  Type VARCHAR(20) NOT NULL
);

CREATE TABLE IF NOT EXISTS Address (
  Id serial not NULL PRIMARY KEY,
  Public_Place VARCHAR(50) NOT NULL,
  Address VARCHAR(255) NOT NULL,
  Number numeric(6) NOT NULL,
  Cep VARCHAR(9) NOT NULL,
  City VARCHAR(100) NOT NULL,
  State VARCHAR(30) NOT NULL,
  Country VARCHAR(50) NOT NULL,
  Complement VARCHAR(50) NULL,
  Neighborhood VARCHAR(50) NOT NULL,
  PersonId int NOT NULL,
  constraint fk_address_person foreign key (PersonId) references Person (Id)
);

CREATE TABLE IF NOT EXISTS Email (
  Id serial not NULL PRIMARY KEY,
  Email VARCHAR(255) NOT NULL,
  IsMain boolean Default FALSE,
  PersonId int NOT NULL,
  constraint fk_email_person foreign key (PersonId) references Person (Id)
);

CREATE TABLE IF NOT EXISTS Phone (
  Id serial not NULL PRIMARY KEY,
  Phone VARCHAR(255) NOT NULL,
  IsMain boolean Default FALSE,
  PersonId int NOT NULL,
  constraint fk_email_person foreign key (PersonId) references Person (Id)
);

 