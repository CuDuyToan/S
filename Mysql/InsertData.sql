use clothes_shop;

INSERT INTO clothes_shop.staffs (Staff_Name, user_name, password, Phone_Number)
 VALUES ('Cù Duy Toản', 'cutoan', 'toan2004', '0335595568');

INSERT INTO clothes_shop.staffs (Staff_Name, user_name, password, Phone_Number)
 VALUES ('ADMIN', 'admin', 'admin@clothesShop', '0123456789');
 
 INSERT INTO clothes_shop.categories (category_name)
	VALUES ('Jeans');

INSERT INTO clothes_shop.categories (category_name)
	VALUES ('T-shirt');

INSERT INTO clothes_shop.categories (category_name)
	VALUES ('Shorts');

INSERT INTO clothes_shop.categories (category_name)
	VALUES ('Shirt');
    
INSERT INTO clothes_shop.categories (category_name)
	VALUES ('Hoodie');
    
INSERT INTO clothes_shop.categories (category_name)
	VALUES ('Sweatshirts');
    
    INSERT INTO clothes_shop.color (color_name)
	VALUES ('Red');
    
INSERT INTO clothes_shop.color (color_name)
	VALUES ('Black');
    
INSERT INTO clothes_shop.color (color_name)
	VALUES ('Blue');
    
INSERT INTO clothes_shop.color (color_name)
	VALUES ('While');
    
INSERT INTO clothes_shop.size (size_name)
	VALUES ('L');
    
INSERT INTO clothes_shop.size (size_name)
	VALUES ('XL');
    
INSERT INTO clothes_shop.size (size_name)
	VALUES ('S');
    
INSERT INTO clothes_shop.size (size_name)
	VALUES ('M');

INSERT INTO Clothes_Shop.clothes (Clothes_Name, Unit_price, Material, Category_ID)
	VALUES ('Nike Solo Swoosh', '2399000', 'Body/Hood Lining: 88% cotton/12% polyester', '6');
  
INSERT INTO clothes_shop.clothes (Clothes_Name, Unit_price, Material, Category_ID)
	VALUES ('Jordan Flight Heritage', '2499000', 'Body: 100% cotton. Rib: 98% cotton/2% elastane. Hood lining: 100% cotton', '5');
    