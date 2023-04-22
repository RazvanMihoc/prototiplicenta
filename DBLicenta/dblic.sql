CREATE TABLE vehicleDB (
    id INT NOT NULL PRIMARY KEY IDENTITY,
    marca VARCHAR (100) NOT NULL,
    model VARCHAR (150) NOT NULL ,
    combustibil VARCHAR(20) NOT NULL,
    an VARCHAR(20) NOT NULL,
    capacitate VARCHAR(20) NOT NULL,
    culoare VARCHAR(20) NOT NULL,
    VIN VARCHAR(100) NOT NULL UNIQUE,
    added_at DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP
);

INSERT INTO vehicleDB (marca, model, combustibil, an, capacitate, culoare, VIN)
VALUES
('Audi', 'A7','Diesel', '2013', '3000', 'Negru','ADSADA'),
('Audi', 'A6','Diesel', '2013', '3000', 'Negru','dasda'),
('BMW', 'Seria 5','Diesel', '2013', '3000', 'Negru','ADSdasADA'),
('BMW', 'A7','Diesel', '2013', '3000', 'Negru','ADSAadafdsDA'),
('MERCEDES', 'A7','Diesel', '2013', '3000', 'Negru','ADSgdfhADA'),
('MERCEDES', 'A7','Diesel', '2013', '3000', 'Negru','ADkhjkhjSADA');