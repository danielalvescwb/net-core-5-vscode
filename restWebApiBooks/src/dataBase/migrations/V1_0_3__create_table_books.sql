CREATE TABLE books (
  id INT IDENTITY(1,1) PRIMARY KEY,
  author text,
  launch_date datetime2 NOT NULL,
  price decimal(19,2) NOT NULL,
  title text,
);
