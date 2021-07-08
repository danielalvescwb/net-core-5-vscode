CREATE TABLE  person (
  id INT IDENTITY(1,1) PRIMARY KEY,
  first_name varchar(80) NOT NULL,
  last_name varchar(80) NOT NULL,
  gender varchar(6) NOT NULL,
  address varchar(100) NOT NULL,
);