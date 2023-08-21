-- MySQL dump 10.13  Distrib 8.0.34, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: clothes_shop
-- ------------------------------------------------------
-- Server version	8.1.0

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `categories`
--

DROP TABLE IF EXISTS `categories`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `categories` (
  `category_ID` int NOT NULL AUTO_INCREMENT,
  `category_name` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`category_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=100 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `categories`
--

LOCK TABLES `categories` WRITE;
/*!40000 ALTER TABLE `categories` DISABLE KEYS */;
INSERT INTO `categories` VALUES (1,'Pants'),(2,'Shirt'),(3,'Skirt'),(4,'Dress'),(5,'Jacket');
/*!40000 ALTER TABLE `categories` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `clothes`
--

DROP TABLE IF EXISTS `clothes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `clothes` (
  `Clothes_ID` int NOT NULL AUTO_INCREMENT,
  `Clothes_Name` varchar(45) NOT NULL,
  `Unit_price` int NOT NULL,
  `Material` varchar(45) NOT NULL,
  `Category_ID` int NOT NULL,
  PRIMARY KEY (`Clothes_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=201 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `clothes`
--

LOCK TABLES `clothes` WRITE;
/*!40000 ALTER TABLE `clothes` DISABLE KEYS */;
INSERT INTO `clothes` VALUES (100,'Wili Wide Pants',410000,'Kaki',1),(101,'Quần Lụa Xếp Ly',410000,'Lụa',1),(102,'Landy Pants',440000,'Cotton',1),(103,'Salted Shorts',360000,'Kaki',1),(104,'Flare Daily Trousers',440000,'Cotton',1),(105,'Daily Chino Pants',440000,'Kaki',1),(106,'Silky Oversized Shirt',450000,'Lụa',2),(107,'Puritan Collar Blouse',420000,'Cotton',2),(108,'Silky Ribbon Blouse',420000,'Lụa',2),(109,'Boat Neckline Crop Top',420000,'Nhung',2),(110,'Runa Sleeveless Top',420000,'Nhung',2),(111,'Áo Dài Tơ',560000,'Tafta',2),(112,'Áo Dài Lụa',510000,'Lụa',2),(113,'Raina Stripe Shirt',390000,'Cotton',2),(114,'Mandarin Collar Shirt',390000,'Cotton',2),(115,'Julie Sleeveless Blouse',290000,'Cotton',2),(116,'Luna Lace Slip Blouse',290000,'Cotton',2),(117,'Yori String Blouse',290000,'Cotton',2),(118,'Pleated Flare Shirt',390000,'Cotton',2),(119,'Pleated Mini Skirt',390000,'Umi',3),(120,'Runa Maxi Skirt',580000,'Nhung',3),(121,'High Waist Max Skirt',580000,'Nhung',3),(122,'Grace Sand Skirt',350000,'Voan',3),(123,'Satin Pleated Skirt',450000,'Satin',3),(124,'Blossom Skirt',480000,'Cotton',3),(125,'Umi Pleats Skirt',420000,'Umi',3),(126,'Satin Long Skirt',380000,'Satin',3),(127,'Fairy Square Neck Dress',560000,'Cotton',4),(128,'Maxi Sleeve Dress',540000,'Bamboo',4),(129,'Balloon Sleeve Mini Dress',690000,'Cotton',4),(130,'Moa Long Dress',490000,'Cotton',4),(131,'Signature Shirts Dress',490000,'Cotton',4),(132,'Maxi Sleeveless Dress',490000,'Bamboo',4),(133,'Grace Sand Jacket',590000,'Voan',5),(134,'Fever Cardigan Jacket',450000,'Voan',5),(135,'Mining Short Jacket',600000,'Voan',5),(136,'Mono Jacket',650000,'Polyester',5),(137,'Wool Tweed Jacket',570000,'Tweed',5),(168,'Wili Wide Pants',410000,'Kaki',1),(169,'Quần Lụa Xếp Ly',410000,'Lụa',1),(170,'Landy Pants',440000,'Cotton',1),(171,'Salted Shorts',360000,'Kaki',1),(172,'Flare Daily Trousers',440000,'Cotton',1),(173,'Daily Chino Pants',440000,'Kaki',1),(174,'Puritan Collar Blouse',420000,'Cotton',2),(175,'Silky Ribbon Blouse',420000,'Lụa',2),(176,'Boat Neckline Crop Top',420000,'Nhung',2),(177,'Runa Sleeveless Top',420000,'Nhung',2),(178,'Áo Dài Tơ',560000,'Tafta',2),(179,'Áo Dài Lụa',510000,'Lụa',2),(180,'Luna Lace Slip Blouse',290000,'Cotton',2),(181,'Pleated Flare Shirt',390000,'Cotton',2),(182,'Pleated Mini Skirt',390000,'Umi',3),(183,'Runa Maxi Skirt',580000,'Nhung',3),(184,'High Waist Max Skirt',580000,'Nhung',3),(185,'Grace Sand Skirt',350000,'Voan',3),(186,'Satin Pleated Skirt',450000,'Satin',3),(187,'Blossom Skirt',480000,'Cotton',3),(188,'Umi Pleats Skirt',420000,'Umi',3),(189,'Satin Long Skirt',380000,'Satin',3),(190,'Fairy Square Neck Dress',560000,'Cotton',4),(191,'Maxi Sleeve Dress',540000,'Bamboo',4),(192,'Balloon Sleeve Mini Dress',690000,'Cotton',4),(193,'Moa Long Dress',490000,'Cotton',4),(194,'Signature Shirts Dress',490000,'Cotton',4),(195,'Maxi Sleeveless Dress',490000,'Bamboo',4),(196,'Grace Sand Jacket',590000,'Voan',5),(197,'Fever Cardigan Jacket',450000,'Voan',5),(198,'Mining Short Jacket',600000,'Voan',5),(199,'Mono Jacket',650000,'Polyester',5),(200,'Wool Tweed Jacket',570000,'Tweed',5);
/*!40000 ALTER TABLE `clothes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `color`
--

DROP TABLE IF EXISTS `color`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `color` (
  `color_ID` int NOT NULL AUTO_INCREMENT,
  `color_name` varchar(15) DEFAULT NULL,
  PRIMARY KEY (`color_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=109 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `color`
--

LOCK TABLES `color` WRITE;
/*!40000 ALTER TABLE `color` DISABLE KEYS */;
INSERT INTO `color` VALUES (1,'Navy'),(2,'Yellow'),(3,'Pink'),(4,'While'),(5,'Green'),(6,'Lilac'),(7,'Ivory'),(104,'Brown'),(105,'Black'),(106,'Beige'),(107,'Light Blue'),(108,'Blue');
/*!40000 ALTER TABLE `color` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `customer`
--

DROP TABLE IF EXISTS `customer`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `customer` (
  `Customer_ID` int NOT NULL AUTO_INCREMENT,
  `Customer_Name` varchar(45) NOT NULL,
  `Phone_Number` varchar(45) NOT NULL,
  `Address` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`Customer_ID`),
  UNIQUE KEY `Phone_Number` (`Phone_Number`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `customer`
--

LOCK TABLES `customer` WRITE;
/*!40000 ALTER TABLE `customer` DISABLE KEYS */;
INSERT INTO `customer` VALUES (1,'Cù Duy Toản','0335595568',NULL),(2,'New','0335559556',NULL),(3,'EXIT','0335595555',NULL),(4,'Toan','1232312312',NULL);
/*!40000 ALTER TABLE `customer` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `orderdetails`
--

DROP TABLE IF EXISTS `orderdetails`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `orderdetails` (
  `OrderDetailID` int NOT NULL AUTO_INCREMENT,
  `Order_ID` int NOT NULL,
  `Clothes_ID` int NOT NULL,
  `Unit_price` int NOT NULL,
  `Quantity` int NOT NULL,
  PRIMARY KEY (`OrderDetailID`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `orderdetails`
--

LOCK TABLES `orderdetails` WRITE;
/*!40000 ALTER TABLE `orderdetails` DISABLE KEYS */;
INSERT INTO `orderdetails` VALUES (1,1,100,410000,1),(2,1,100,410000,1),(3,1,100,410000,1),(4,1,100,410000,1),(5,1,100,410000,1),(6,2,100,410000,5),(7,3,100,410000,0),(8,4,100,410000,1),(9,7,100,410000,1),(10,8,100,410000,3);
/*!40000 ALTER TABLE `orderdetails` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `orders`
--

DROP TABLE IF EXISTS `orders`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `orders` (
  `Order_ID` int NOT NULL,
  `Customer_ID` int NOT NULL,
  `Customer_Phone` varchar(10) NOT NULL,
  `Staff_ID` int NOT NULL,
  `Create_at` datetime NOT NULL,
  `Create_by` varchar(45) NOT NULL,
  `Total_price` int NOT NULL,
  `status` varchar(45) NOT NULL,
  PRIMARY KEY (`Order_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `orders`
--

LOCK TABLES `orders` WRITE;
/*!40000 ALTER TABLE `orders` DISABLE KEYS */;
INSERT INTO `orders` VALUES (0,0,'0',0,'2023-08-07 13:16:29','0',0,'0'),(1,1,'0335595568',1,'2023-08-07 13:22:19','Cù Duy Toản',2050000,'0'),(2,1,'0335595568',1,'2023-08-07 13:35:36','Cù Duy Toản',2050000,'0'),(3,1,'0335595568',1,'2023-08-13 02:02:45','Cù Duy Toản',410000,'0'),(4,1,'0335595568',1,'2023-08-13 02:13:57','Cù Duy Toản',410000,'0'),(5,1,'0335595568',1,'2023-08-14 16:15:19','Cù Duy Toản',4920000,'0'),(6,1,'0335595568',1,'2023-08-15 02:36:17','Cù Duy Toản',410000,'0'),(7,1,'0335595568',1,'2023-08-15 18:23:52','Cù Duy Toản',410000,'1'),(8,1,'0335595568',1,'2023-08-15 21:57:29','Cù Duy Toản',1230000,'1');
/*!40000 ALTER TABLE `orders` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `size`
--

DROP TABLE IF EXISTS `size`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `size` (
  `size_ID` int NOT NULL AUTO_INCREMENT,
  `size_name` varchar(10) DEFAULT NULL,
  PRIMARY KEY (`size_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=107 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `size`
--

LOCK TABLES `size` WRITE;
/*!40000 ALTER TABLE `size` DISABLE KEYS */;
INSERT INTO `size` VALUES (1,'S'),(2,'M'),(100,'One Size'),(101,'28'),(102,'29'),(103,'30'),(104,'31'),(105,'32'),(106,'33');
/*!40000 ALTER TABLE `size` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `size_color`
--

DROP TABLE IF EXISTS `size_color`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `size_color` (
  `size_color_ID` int NOT NULL AUTO_INCREMENT,
  `clothes_ID` int NOT NULL,
  `color_ID` int NOT NULL,
  `size_ID` int NOT NULL,
  `quantity` int NOT NULL,
  PRIMARY KEY (`size_color_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=171 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `size_color`
--

LOCK TABLES `size_color` WRITE;
/*!40000 ALTER TABLE `size_color` DISABLE KEYS */;
INSERT INTO `size_color` VALUES (100,100,104,106,84),(101,168,104,101,100),(102,101,4,105,100),(103,169,4,102,100),(104,102,105,104,100),(105,170,105,103,100),(106,103,106,103,100),(107,171,106,104,100),(108,104,105,102,100),(109,172,105,105,100),(110,105,105,101,100),(111,173,105,106,100),(112,106,6,100,100),(113,107,4,1,100),(114,174,4,2,100),(115,108,4,1,100),(116,175,4,2,100),(117,109,4,1,100),(118,176,4,2,100),(119,110,106,1,100),(120,177,106,2,100),(121,111,6,1,100),(122,178,6,2,100),(123,112,5,1,100),(124,179,5,2,100),(125,113,5,100,100),(126,114,1,100,100),(127,115,1,100,100),(128,116,5,1,100),(129,180,5,2,100),(130,117,107,100,100),(131,118,4,1,100),(132,181,4,2,100),(133,119,105,1,100),(134,182,105,2,100),(135,120,106,1,100),(136,183,106,2,100),(137,121,4,1,100),(138,184,4,2,100),(139,122,1,1,100),(140,185,1,2,100),(141,123,1,1,100),(142,186,1,2,100),(143,124,4,1,100),(144,187,4,2,100),(145,125,105,1,100),(146,188,105,2,100),(147,126,4,1,100),(148,189,4,2,100),(149,127,106,1,100),(150,190,10,2,3),(151,128,7,1,4),(152,191,7,2,5),(153,129,4,1,4),(154,192,4,2,7),(155,130,1,1,5),(156,193,1,2,8),(157,131,1,1,4),(158,194,1,2,5),(159,132,7,1,3),(160,195,7,2,6),(161,133,1,1,4),(162,196,1,2,6),(163,134,11,1,8),(164,197,11,2,5),(165,135,8,1,5),(166,198,8,2,9),(167,136,10,1,4),(168,199,10,2,5),(169,137,12,1,3),(170,200,12,2,2);
/*!40000 ALTER TABLE `size_color` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `staffs`
--

DROP TABLE IF EXISTS `staffs`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `staffs` (
  `Staff_ID` int NOT NULL AUTO_INCREMENT,
  `Staff_Name` varchar(45) NOT NULL,
  `user_name` varchar(45) NOT NULL,
  `password` varchar(45) NOT NULL,
  `Phone_Number` varchar(10) NOT NULL,
  PRIMARY KEY (`Staff_ID`,`user_name`),
  UNIQUE KEY `user_name` (`user_name`),
  UNIQUE KEY `Phone_Number` (`Phone_Number`)
) ENGINE=InnoDB AUTO_INCREMENT=100 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `staffs`
--

LOCK TABLES `staffs` WRITE;
/*!40000 ALTER TABLE `staffs` DISABLE KEYS */;
INSERT INTO `staffs` VALUES (1,'Cù Duy Toản','cutoan','c461582490196cbf98060581685ecddf','0335595568'),(2,'Mai Thị Hồng Minh','hongminh','d47b9a0558e326bf27b13f95e0105767','0385382840'),(3,'ADMIN','admin','1894c85e98109098deff51ce6627351f','0123456789');
/*!40000 ALTER TABLE `staffs` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-08-22  0:46:03
