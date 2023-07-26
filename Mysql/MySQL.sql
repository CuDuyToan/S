create schema Clothes_Shop;

-- drop schema Clothes_Shop;

-- use clothes_shop;

CREATE TABLE Clothes_Shop.staffs (
  Staff_ID INT NOT NULL auto_increment,
  Staff_Name VARCHAR(45) NOT NULL,
  user_name VARCHAR(45) NOT NULL unique,
  password VARCHAR(45) NOT NULL,
  Phone_Number VARCHAR(10) NOT NULL unique,
  PRIMARY KEY (Staff_ID, user_name));

INSERT INTO clothes_shop.staffs (Staff_Name, user_name, password, Phone_Number)
 VALUES ('Cù Duy Toản', 'admin', 'toan2004', '0335595568');

INSERT INTO clothes_shop.staffs (Staff_Name, user_name, password, Phone_Number)
 VALUES ('ai do', 'someone', 'toan2004', '0123456789');
 
CREATE TABLE Clothes_Shop.orders (
    Order_ID INT NOT NULL AUTO_INCREMENT,
    Customer_ID INT NOT NULL,
    Customer_Phone varchar(10) not null,
    Staff_ID INT NOT NULL,
    Create_at DATETIME NOT NULL,
    Create_by varchar(45) NOT NULL,
    Total_price INT NOT NULL,
    status VARCHAR(45) NOT NULL,
-- 	foreign key(Order_ID) references OrdersDetails(Order_ID),
    PRIMARY KEY (Order_ID)
);

CREATE TABLE Clothes_Shop.categories (
	category_ID INT NOT NULL AUTO_INCREMENT,
    category_name varchar(45),
    PRIMARY KEY (category_ID)
);

INSERT INTO clothes_shop.categories (category_name)
	VALUES ('Jeans');

INSERT INTO clothes_shop.categories (category_name)
	VALUES ('T-shirt');

INSERT INTO clothes_shop.categories (category_name)
	VALUES ('Shorts');

INSERT INTO clothes_shop.categories (category_name)
	VALUES ('Shirt');
    
CREATE TABLE Clothes_Shop.size_color (
	size_color_ID INT NOT NULL AUTO_INCREMENT,
	clothes_ID INT NOT NULL,
    color_ID INT NOT NULL,
    size_ID INT NOT NULL,
    quantity INT NOT NULL,
    PRIMARY KEY (size_color_ID)
);

CREATE TABLE Clothes_Shop.color (
	color_ID INT NOT NULL AUTO_INCREMENT,
    color_name varchar(15),
    PRIMARY KEY (color_ID)
);

INSERT INTO clothes_shop.color (color_name)
	VALUES ('Red');
    
INSERT INTO clothes_shop.color (color_name)
	VALUES ('Black');
    
INSERT INTO clothes_shop.color (color_name)
	VALUES ('Blue');
    
INSERT INTO clothes_shop.color (color_name)
	VALUES ('While');

  CREATE TABLE Clothes_Shop.size (
	size_ID INT NOT NULL AUTO_INCREMENT,
    size_name varchar(5),
    PRIMARY KEY (size_ID)
);


INSERT INTO clothes_shop.size (size_name)
	VALUES ('L');
    
INSERT INTO clothes_shop.size (size_name)
	VALUES ('Xl');

CREATE TABLE Clothes_Shop.clothes (
    Clothes_ID INT NOT NULL AUTO_INCREMENT,
    Clothes_Name VARCHAR(45) NOT NULL,
    Unit_price INT NOT NULL,
    Material VARCHAR(45) NOT NULL,
    Category_ID INT NOT NULL,
--     User_manual VARCHAR(45) NOT NULL,
    PRIMARY KEY (Clothes_ID)
);
  
INSERT INTO Clothes_Shop.clothes (Clothes_Name, Unit_price, Material, Category_ID)
	VALUES ('Hoodie', '132000', 'bla bla', '4');
  
INSERT INTO clothes_shop.clothes (Clothes_Name, Unit_price, Material, Category_ID)
	VALUES ('sweatshirt.', '99000', 'bla bla', '4');
    
CREATE TABLE Clothes_Shop.OrderDetails(
    Order_ID INT NOT NULL,
    Clothes_ID INT NOT NULL,
    Unit_price INT NOT NULL,
    Quantity INT NOT NULL,
    foreign key(Clothes_ID) references clothes(Clothes_ID),
    PRIMARY KEY (Order_ID, Clothes_ID)
);
    
CREATE TABLE Clothes_Shop.customer (
    Customer_ID INT NOT NULL AUTO_INCREMENT,
    Customer_Name VARCHAR(45) NOT NULL,
    Phone_Number VARCHAR(45) NOT NULL unique,
    Address VARCHAR(45),
    PRIMARY KEY (Customer_ID)
);
    
ALTER TABLE customer AUTO_INCREMENT=100;
ALTER TABLE staffs AUTO_INCREMENT=100;
ALTER TABLE orders AUTO_INCREMENT=100;
ALTER TABLE categories AUTO_INCREMENT=100;
ALTER TABLE clothes AUTO_INCREMENT=100;
ALTER TABLE color AUTO_INCREMENT=100;
ALTER TABLE size AUTO_INCREMENT=100;
ALTER TABLE size_color AUTO_INCREMENT=100;