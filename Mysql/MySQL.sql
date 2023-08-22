create schema Clothes_Shop;

-- drop schema Clothes_Shop;

use clothes_shop;

CREATE TABLE Clothes_Shop.staffs (
  Staff_ID INT NOT NULL auto_increment,
  Staff_Name VARCHAR(45) NOT NULL,
  user_name VARCHAR(45) NOT NULL unique,
  password VARCHAR(45) NOT NULL,
  Phone_Number VARCHAR(10) NOT NULL unique,
  PRIMARY KEY (Staff_ID, user_name));

INSERT INTO clothes_shop.staffs (Staff_Name, user_name, password, Phone_Number)
 VALUES ('Cù Duy Toản', 'cutoan', 'toan2004', '0335595568');

INSERT INTO clothes_shop.staffs (Staff_Name, user_name, password, Phone_Number)
 VALUES ('Mai Thị Hồng Minh', 'hongminh', 'minh2004', '0385382840');
 
INSERT INTO clothes_shop.staffs (Staff_Name, user_name, password, Phone_Number)
 VALUES ('ADMIN', 'admin', 'admin@clothesShop', '0123456789');
 
 -- drop table clothes_shop.orders;
CREATE TABLE Clothes_Shop.orders (
    Order_ID INT NOT NULL,
    Customer_ID INT NOT NULL,
    Customer_Phone varchar(10) not null,
    Staff_ID INT NOT NULL,
    Create_at DATETIME NOT NULL,
    Create_by varchar(45) NOT NULL,
    Total_price INT NOT NULL,
    Payment_method varchar(50),
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
	VALUES ('Pants');

INSERT INTO clothes_shop.categories (category_name)
	VALUES ('Shirt');

INSERT INTO clothes_shop.categories (category_name)
	VALUES ('Skirt');

INSERT INTO clothes_shop.categories (category_name)
	VALUES ('Dress');
    
INSERT INTO clothes_shop.categories (category_name)
	VALUES ('Jacket');
    
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
	VALUES ('Navy');
    
INSERT INTO clothes_shop.color (color_name)
	VALUES ('Yellow');
    
INSERT INTO clothes_shop.color (color_name)
	VALUES ('Pink');
    
INSERT INTO clothes_shop.color (color_name)
	VALUES ('While');
    
INSERT INTO clothes_shop.color (color_name)
	VALUES ('Green');
    
INSERT INTO clothes_shop.color (color_name)
	VALUES ('Lilac');
    
INSERT INTO clothes_shop.color (color_name)
	VALUES ('Ivory');

  CREATE TABLE Clothes_Shop.size (
	size_ID INT NOT NULL AUTO_INCREMENT,
    size_name varchar(5),
    PRIMARY KEY (size_ID)
);

INSERT INTO clothes_shop.size (size_name)
	VALUES ('S');
    
INSERT INTO clothes_shop.size (size_name)
	VALUES ('M');

CREATE TABLE Clothes_Shop.clothes (
    Clothes_ID INT NOT NULL AUTO_INCREMENT,
    Clothes_Name VARCHAR(45) NOT NULL,
    Unit_price INT NOT NULL,
    Material VARCHAR(45) NOT NULL,
    Category_ID INT NOT NULL,
--     User_manual VARCHAR(45) NOT NULL,
    PRIMARY KEY (Clothes_ID)
);
    
CREATE TABLE Clothes_Shop.OrderDetails(
	OrderDetailID INT NOT NULL AUTO_INCREMENT,
    Order_ID INT NOT NULL,
    Clothes_ID INT NOT NULL,
    Unit_price INT NOT NULL,
    Quantity INT NOT NULL,
    -- foreign key(Clothes_ID) references clothes(Clothes_ID),
    PRIMARY KEY (OrderDetailID)
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
ALTER TABLE orderdetails AUTO_INCREMENT=100;
-- ALTER TABLE orders AUTO_INCREMENT=100;
ALTER TABLE categories AUTO_INCREMENT=100;
ALTER TABLE clothes AUTO_INCREMENT=100;
ALTER TABLE color AUTO_INCREMENT=100;
ALTER TABLE size AUTO_INCREMENT=100;
ALTER TABLE size_color AUTO_INCREMENT=100;