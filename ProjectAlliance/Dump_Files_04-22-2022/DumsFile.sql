-- MySQL dump 10.13  Distrib 8.0.26, for macos11 (x86_64)
--
-- Host: localhost    Database: projetalliance
-- ------------------------------------------------------
-- Server version	8.0.26

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Current Database: `projetalliance`
--

CREATE DATABASE /*!32312 IF NOT EXISTS*/ `projetalliance` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;

USE `projetalliance`;

--
-- Table structure for table `__EFMigrationsHistory`
--

DROP TABLE IF EXISTS `__EFMigrationsHistory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `__EFMigrationsHistory` (
  `MigrationId` varchar(150) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `__EFMigrationsHistory`
--

LOCK TABLES `__EFMigrationsHistory` WRITE;
/*!40000 ALTER TABLE `__EFMigrationsHistory` DISABLE KEYS */;
INSERT INTO `__EFMigrationsHistory` VALUES ('20220610073257_initial','3.1.22');
/*!40000 ALTER TABLE `__EFMigrationsHistory` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Company`
--

DROP TABLE IF EXISTS `Company`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Company` (
  `id` int NOT NULL AUTO_INCREMENT,
  `companyName` varchar(30) DEFAULT NULL,
  `createdBy` text,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Company`
--

LOCK TABLES `Company` WRITE;
/*!40000 ALTER TABLE `Company` DISABLE KEYS */;
INSERT INTO `Company` VALUES (1,'uiit','as1265513@uiit.pa.com');
/*!40000 ALTER TABLE `Company` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `DesignAttachments`
--

DROP TABLE IF EXISTS `DesignAttachments`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `DesignAttachments` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` text,
  `designId` int NOT NULL,
  `AttachmentPath` text,
  `AttachmentExtension` text,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `DesignAttachments`
--

LOCK TABLES `DesignAttachments` WRITE;
/*!40000 ALTER TABLE `DesignAttachments` DISABLE KEYS */;
/*!40000 ALTER TABLE `DesignAttachments` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Designs`
--

DROP TABLE IF EXISTS `Designs`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Designs` (
  `id` int NOT NULL AUTO_INCREMENT,
  `Name` text,
  `Description` text,
  `url` text,
  `folderId` int NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Designs`
--

LOCK TABLES `Designs` WRITE;
/*!40000 ALTER TABLE `Designs` DISABLE KEYS */;
/*!40000 ALTER TABLE `Designs` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `documentSection`
--

DROP TABLE IF EXISTS `documentSection`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `documentSection` (
  `sectionId` int NOT NULL AUTO_INCREMENT,
  `sectionName` varchar(30) DEFAULT NULL,
  `sectionDescription` text,
  `projectId` int NOT NULL,
  PRIMARY KEY (`sectionId`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `documentSection`
--

LOCK TABLES `documentSection` WRITE;
/*!40000 ALTER TABLE `documentSection` DISABLE KEYS */;
INSERT INTO `documentSection` VALUES (1,'asasd','asdasd',1);
/*!40000 ALTER TABLE `documentSection` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `enviornment`
--

DROP TABLE IF EXISTS `enviornment`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `enviornment` (
  `id` int NOT NULL AUTO_INCREMENT,
  `Name` text,
  `Description` text,
  `summary` text,
  `projectId` int NOT NULL,
  `TestType` text,
  `RequirementId` int NOT NULL,
  `isRequirementBased` tinyint(1) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `enviornment`
--

LOCK TABLES `enviornment` WRITE;
/*!40000 ALTER TABLE `enviornment` DISABLE KEYS */;
INSERT INTO `enviornment` VALUES (1,'Android','Android Based','Document',1,'Document',0,0);
/*!40000 ALTER TABLE `enviornment` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Files`
--

DROP TABLE IF EXISTS `Files`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Files` (
  `DocumentId` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(100) DEFAULT NULL,
  `FileType` varchar(100) DEFAULT NULL,
  `DataFiles` varbinary(4000) DEFAULT NULL,
  `CreatedOn` datetime DEFAULT NULL,
  PRIMARY KEY (`DocumentId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Files`
--

LOCK TABLES `Files` WRITE;
/*!40000 ALTER TABLE `Files` DISABLE KEYS */;
/*!40000 ALTER TABLE `Files` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `folders`
--

DROP TABLE IF EXISTS `folders`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `folders` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` text,
  `projectId` int NOT NULL,
  `modifiedBy` int NOT NULL,
  `folderType` text,
  `modifeidOn` date NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `folders`
--

LOCK TABLES `folders` WRITE;
/*!40000 ALTER TABLE `folders` DISABLE KEYS */;
/*!40000 ALTER TABLE `folders` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Goals`
--

DROP TABLE IF EXISTS `Goals`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Goals` (
  `id` int NOT NULL AUTO_INCREMENT,
  `goalName` varchar(30) DEFAULT NULL,
  `goalDescription` text,
  `startDate` date NOT NULL,
  `endDate` date NOT NULL,
  `companyId` int NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Goals`
--

LOCK TABLES `Goals` WRITE;
/*!40000 ALTER TABLE `Goals` DISABLE KEYS */;
/*!40000 ALTER TABLE `Goals` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `labResource`
--

DROP TABLE IF EXISTS `labResource`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `labResource` (
  `id` int NOT NULL AUTO_INCREMENT,
  `Name` text,
  `value` text,
  `EnvId` int NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `labResource`
--

LOCK TABLES `labResource` WRITE;
/*!40000 ALTER TABLE `labResource` DISABLE KEYS */;
INSERT INTO `labResource` VALUES (1,'window','Xp',1);
/*!40000 ALTER TABLE `labResource` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `mail`
--

DROP TABLE IF EXISTS `mail`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `mail` (
  `id` int NOT NULL AUTO_INCREMENT,
  `subject` text,
  `title` text,
  `description` text,
  `time` datetime NOT NULL,
  `to` text,
  `from` text,
  `isRead` tinyint(1) NOT NULL,
  `isStared` tinyint(1) NOT NULL,
  `company` text,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=42 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `mail`
--

LOCK TABLES `mail` WRITE;
/*!40000 ALTER TABLE `mail` DISABLE KEYS */;
INSERT INTO `mail` VALUES (4,'Mail Send Testing','This Is mail Test From Postman','Yes We are Checking','2022-06-10 12:35:56','test@uiit.pa.com','as1265513@uiit.pa.com',1,0,'uiit'),(6,'Mail Send Testing','This Is mail Test From Postman','Yes We are Checking','2022-06-10 12:37:15','test@uiit.pa.com','as1265513@uiit.pa.com',1,0,'uiit'),(8,'Mail Send Testing','This Is mail Test From Postman','Yes We are Checking','2022-06-10 12:37:18','test@uiit.pa.com','as1265513@uiit.pa.com',1,0,'uiit'),(12,'Pakistan zindbad','This Is mail Test From Postman','Yes We are Checking','2022-06-10 12:53:09','test@uiit.pa.com','test@uiit.pa.com',0,0,'uiit'),(13,'Pakistan zindbad','This Is mail Test From Postman','Yes We are Checking','2022-06-10 12:53:57','test@uiit.pa.com','test@uiit.pa.com',0,0,'uiit'),(14,'Pakistan zindbad','This Is mail Test From Postman','Yes We are Checking','2022-06-10 12:53:57','test@uiit.pa.com','test@uiit.pa.com',0,0,'uiit'),(15,'Pakistan','Pakistan','Pakistan','2022-06-10 18:11:47','rehan@uiit.pa.com','as1265513@uiit.pa.com',1,0,'uiit'),(16,'sadkjasl','kfjaklfj','sklfjslkdfj','2022-06-10 18:15:26','waqas@gmail.com','as1265513@uiit.pa.com',1,0,'uiit'),(19,'Indial','Idia','Idia is THe Message','2022-06-10 22:43:29','rehan@uiit.pa.com','as1265513@uiit.pa.com',1,0,'uiit'),(25,'asdas','asdasdas','asd','2022-06-10 22:51:41','rehan@uiit.pa.com','as1265513@uiit.pa.com',1,0,'uiit'),(31,'samdna','sam,d','asm,d','2022-06-11 14:38:40','rehan@uiit.pa.com','as1265513@uiit.pa.com',1,0,'uiit'),(32,'zxz','zx','zx','2022-06-11 14:41:18','as1265513@uiit.pa.com','as1265513@uiit.pa.com',1,1,'uiit'),(33,'zxz','zx','zx','2022-06-11 14:41:18','rehan@uiit.pa.com','as1265513@uiit.pa.com',1,0,'uiit'),(34,'zxz','zxzzxzzx','zxzxzzxz','2022-06-11 14:42:08','as1265513@uiit.pa.com','as1265513@uiit.pa.com',1,1,'uiit'),(35,'zxz','zxzzxzzx','zxzxzzxz','2022-06-11 14:42:08','rehan@uiit.pa.com','as1265513@uiit.pa.com',1,0,'uiit'),(36,'asd','asd','asd','2022-06-11 14:54:20','as1265513@uiit.pa.com','as1265513@uiit.pa.com',1,0,'uiit'),(37,'asd','asd','asd','2022-06-11 14:54:20','rehan@uiit.pa.com','as1265513@uiit.pa.com',1,0,'uiit'),(38,'asd','asdsa','asdasdasdas','2022-06-11 17:25:25','as1265513@uiit.pa.com','as1265513@uiit.pa.com',1,0,'uiit'),(39,'asd','asdsa','asdasdasdas','2022-06-11 17:25:25','rehan@uiit.pa.com','as1265513@uiit.pa.com',1,0,'uiit'),(40,'Home EMail Test','asda','Testing HOme Emial','2022-06-12 11:08:32','as1265513@uiit.pa.com','as1265513@uiit.pa.com',1,0,'uiit'),(41,'Home EMail Test','asda','Testing HOme Emial','2022-06-12 11:08:33','rehan@uiit.pa.com','as1265513@uiit.pa.com',1,0,'uiit');
/*!40000 ALTER TABLE `mail` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `mailAttachments`
--

DROP TABLE IF EXISTS `mailAttachments`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `mailAttachments` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` text,
  `emailId` int NOT NULL,
  `path` text,
  `ext` text,
  `fakeName` text,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=72 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `mailAttachments`
--

LOCK TABLES `mailAttachments` WRITE;
/*!40000 ALTER TABLE `mailAttachments` DISABLE KEYS */;
INSERT INTO `mailAttachments` VALUES (1,'Assignment-II (3415).pdf',0,'http://192.168.43.107:5005/api/Document/FileAPI/f9f6dae5-95b5-46fd-beab-9e1aaed9ffe9Files.pdf','f9f6dae5-95b5-46fd-beab-9e1aaed9ffe9Files.pdf',NULL),(2,'AzeemSarwar.pdf',0,'http://192.168.43.107:5005/api/Document/FileAPI/6b127328-2378-43f8-b706-f6a907e80e9dFiles.pdf','6b127328-2378-43f8-b706-f6a907e80e9dFiles.pdf',NULL),(3,'AzeemSarwar.pdf',0,'http://192.168.43.107:5005/api/Document/FileAPI/2049fc27-6ee0-4bcb-b6e2-73fe336c0c99Files.pdf','2049fc27-6ee0-4bcb-b6e2-73fe336c0c99Files.pdf',NULL),(4,'Assignment-II (3415).pdf',0,'http://192.168.43.107:5005/api/Document/FileAPI/51e3d02d-c1e0-4d81-bdfd-c386e23a567eFiles.pdf','51e3d02d-c1e0-4d81-bdfd-c386e23a567eFiles.pdf',NULL),(5,'Assignment-II (3415).pdf',0,'http://192.168.43.107:5005/api/Document/FileAPI/834ef114-0724-4ce4-a53c-43f04f682c71Files.pdf','834ef114-0724-4ce4-a53c-43f04f682c71Files.pdf',NULL),(6,'AzeemSarwar.pdf',0,'http://192.168.43.107:5005/api/Document/FileAPI/d9b3288c-6d66-4cbb-b3a0-76506fb92b49Files.pdf','d9b3288c-6d66-4cbb-b3a0-76506fb92b49Files.pdf',NULL),(7,'AzeemSarwar.pdf',0,'http://192.168.43.107:5005/api/Document/FileAPI/b6b008a6-595d-4f2b-80ca-419388228f93Files.pdf','b6b008a6-595d-4f2b-80ca-419388228f93Files.pdf',NULL),(8,'Assignment-II (3415).pdf',0,'http://192.168.43.107:5005/api/Document/FileAPI/ff150776-bf9b-4aa5-90ed-9844167f7706Files.pdf','ff150776-bf9b-4aa5-90ed-9844167f7706Files.pdf',NULL),(11,'AzeemSarwar.pdf',6,'http://192.168.43.107:5005/api/Document/FileAPI/55ef5a74-16e6-4b59-802f-0c35c094a37cFiles.pdf','55ef5a74-16e6-4b59-802f-0c35c094a37cFiles.pdf',NULL),(12,'Assignment-II (3415).pdf',6,'http://192.168.43.107:5005/api/Document/FileAPI/028c75a4-b82c-4776-9252-3afd3e6b48ceFiles.pdf','028c75a4-b82c-4776-9252-3afd3e6b48ceFiles.pdf',NULL),(15,'AzeemSarwar.pdf',8,'http://192.168.43.107:5005/api/Document/FileAPI/4f42e195-4870-4665-a6a4-7b0c23e8137eFiles.pdf','4f42e195-4870-4665-a6a4-7b0c23e8137eFiles.pdf',NULL),(16,'Assignment-II (3415).pdf',8,'http://192.168.43.107:5005/api/Document/FileAPI/618d4b11-26f5-445f-b7a8-9f75d7c520d2Files.pdf','618d4b11-26f5-445f-b7a8-9f75d7c520d2Files.pdf',NULL),(23,'AzeemSarwar.pdf',12,'http://192.168.43.107:5005/api/Document/FileAPI/46fc1fae-4f58-44c8-a30f-fdfc2cb70301Files.pdf','46fc1fae-4f58-44c8-a30f-fdfc2cb70301Files.pdf',NULL),(24,'Assignment-II (3415).pdf',12,'http://192.168.43.107:5005/api/Document/FileAPI/bad0049f-43ad-497a-ba32-7b5b832aecc6Files.pdf','bad0049f-43ad-497a-ba32-7b5b832aecc6Files.pdf',NULL),(25,'Assignment-II (3415).pdf',13,'http://192.168.43.107:5005/api/Document/FileAPI/68a1cdbb-0951-4027-802f-41a27edc55a0Files.pdf','68a1cdbb-0951-4027-802f-41a27edc55a0Files.pdf',NULL),(26,'AzeemSarwar.pdf',13,'http://192.168.43.107:5005/api/Document/FileAPI/7524f9f2-f2c8-4761-8ef0-2e0bcc0f32e9Files.pdf','7524f9f2-f2c8-4761-8ef0-2e0bcc0f32e9Files.pdf',NULL),(27,'AzeemSarwar.pdf',14,'http://192.168.43.107:5005/api/Document/FileAPI/f7d62bf7-e62d-455e-a892-54ddbd8a2875Files.pdf','f7d62bf7-e62d-455e-a892-54ddbd8a2875Files.pdf',NULL),(28,'Assignment-II (3415).pdf',14,'http://192.168.43.107:5005/api/Document/FileAPI/cdd3f858-d20b-425c-8a8b-1fe92612d7d0Files.pdf','cdd3f858-d20b-425c-8a8b-1fe92612d7d0Files.pdf',NULL),(29,'Architecture.pdf',15,'http://192.168.43.107:5005/api/Document/FileAPI/f38a8925-5e83-4f0f-b34b-014179362cecFiles.pdf','f38a8925-5e83-4f0f-b34b-014179362cecFiles.pdf',NULL),(30,'Assignment-II (3415) (1).pdf',15,'http://192.168.43.107:5005/api/Document/FileAPI/80561e44-3652-45e1-84c0-4f9be8079b4bFiles.pdf','80561e44-3652-45e1-84c0-4f9be8079b4bFiles.pdf',NULL),(31,'Assignment-II (3415) (1).pdf',16,'http://192.168.43.107:5005/api/Document/FileAPI/523ca53d-ec08-4654-8708-b96576755d3fFiles.pdf','523ca53d-ec08-4654-8708-b96576755d3fFiles.pdf',NULL),(32,'Assignment-II (3415).pdf',16,'http://192.168.43.107:5005/api/Document/FileAPI/4e532cd9-70fb-47c6-a582-438d71085b98Files.pdf','4e532cd9-70fb-47c6-a582-438d71085b98Files.pdf',NULL),(33,'AzeemSarwar.pdf',16,'http://192.168.43.107:5005/api/Document/FileAPI/8ca480b3-3713-4160-9797-ce73a1418309Files.pdf','8ca480b3-3713-4160-9797-ce73a1418309Files.pdf',NULL),(39,'Assignment-II (3415).pdf',19,'http://192.168.43.107:5005/api/Document/FileAPI/9fcc18c6-11b0-4c42-97fc-5b93adea64e7Files.pdf','9fcc18c6-11b0-4c42-97fc-5b93adea64e7Files.pdf',NULL),(40,'Assignment-II (3415) (1).pdf',19,'http://192.168.43.107:5005/api/Document/FileAPI/e1117c73-5c90-4788-bbe3-3f24532cf812Files.pdf','e1117c73-5c90-4788-bbe3-3f24532cf812Files.pdf',NULL),(46,'flobroLOGO.png',25,'http://192.168.43.107:5005/api/Document/FileAPI/bd22e0e1-5b0e-434d-8ca0-a190efc3027bFiles.png','bd22e0e1-5b0e-434d-8ca0-a190efc3027bFiles.png',NULL),(55,'AzeemSarwar.pdf',31,'http://192.168.43.107:5005/api/Document/FileAPI/a0bd7169-4182-4adc-a8fa-9b4c55b32d29Files.pdf','a0bd7169-4182-4adc-a8fa-9b4c55b32d29Files.pdf',NULL),(56,'240dcb86-0be6-4c4b-8ecd-88664755c2f6Files.docx',32,'http://192.168.43.107:5005/api/Document/FileAPI/24777039-ec26-4b0c-b543-aa6a9982adb7Files.docx','24777039-ec26-4b0c-b543-aa6a9982adb7Files.docx',NULL),(57,'240dcb86-0be6-4c4b-8ecd-88664755c2f6Files.docx',33,'http://192.168.43.107:5005/api/Document/FileAPI/2b4e3f4f-3682-466d-a1f9-04dd6f0c2a83Files.docx','2b4e3f4f-3682-466d-a1f9-04dd6f0c2a83Files.docx',NULL),(58,'240dcb86-0be6-4c4b-8ecd-88664755c2f6Files.docx',34,'http://192.168.43.107:5005/api/Document/FileAPI/0e3e5316-7eed-457f-a003-38d88416f849Files.docx','0e3e5316-7eed-457f-a003-38d88416f849Files.docx',NULL),(59,'flobroLOGO.png',34,'http://192.168.43.107:5005/api/Document/FileAPI/afabb103-9fed-49e0-855e-bd21c57a3f28Files.png','afabb103-9fed-49e0-855e-bd21c57a3f28Files.png',NULL),(60,'gmail.jpeg',34,'http://192.168.43.107:5005/api/Document/FileAPI/55284f7a-5cbf-4178-8e3a-af6302b9d1e1Files.jpeg','55284f7a-5cbf-4178-8e3a-af6302b9d1e1Files.jpeg',NULL),(61,'image (1).png',34,'http://192.168.43.107:5005/api/Document/FileAPI/a8abb8eb-161f-47fb-a59f-e9182e5cb54bFiles.png','a8abb8eb-161f-47fb-a59f-e9182e5cb54bFiles.png',NULL),(62,'image (1).png',35,'http://192.168.43.107:5005/api/Document/FileAPI/3213ea34-ef3c-46a8-8fd7-9af295947349Files.png','3213ea34-ef3c-46a8-8fd7-9af295947349Files.png',NULL),(63,'gmail.jpeg',35,'http://192.168.43.107:5005/api/Document/FileAPI/73bf7fab-c34e-44c6-957e-7b723e12fd57Files.jpeg','73bf7fab-c34e-44c6-957e-7b723e12fd57Files.jpeg',NULL),(64,'flobroLOGO.png',35,'http://192.168.43.107:5005/api/Document/FileAPI/aae465d2-8bd8-4356-9003-ba9d06143143Files.png','aae465d2-8bd8-4356-9003-ba9d06143143Files.png',NULL),(65,'240dcb86-0be6-4c4b-8ecd-88664755c2f6Files.docx',35,'http://192.168.43.107:5005/api/Document/FileAPI/7bed1e38-ae36-4e0e-bdad-08cdc975ec2bFiles.docx','7bed1e38-ae36-4e0e-bdad-08cdc975ec2bFiles.docx',NULL),(66,'AzeemSarwar.pdf',36,'http://192.168.43.107:5005/api/Document/FileAPI/f8c35760-76b5-4793-b669-8687aff34a5dFiles.pdf','f8c35760-76b5-4793-b669-8687aff34a5dFiles.pdf',NULL),(67,'AzeemSarwar.pdf',37,'http://192.168.43.107:5005/api/Document/FileAPI/8deb1b5e-5cdd-4077-8cd0-d6e9e4dee105Files.pdf','8deb1b5e-5cdd-4077-8cd0-d6e9e4dee105Files.pdf',NULL),(68,'Architecture.pdf',40,'http://192.168.43.107:5005/api/Document/FileAPI/07d1e8fa-e204-452e-b24a-bf011fb750baFiles.pdf','07d1e8fa-e204-452e-b24a-bf011fb750baFiles.pdf',NULL),(69,'Assignment-II (3415).pdf',40,'http://192.168.43.107:5005/api/Document/FileAPI/95328306-a1bc-4689-a705-de950fe1dfc7Files.pdf','95328306-a1bc-4689-a705-de950fe1dfc7Files.pdf',NULL),(70,'Assignment-II (3415).pdf',41,'http://192.168.43.107:5005/api/Document/FileAPI/45514503-49f3-4ccf-a5cf-09dd7039d4feFiles.pdf','45514503-49f3-4ccf-a5cf-09dd7039d4feFiles.pdf',NULL),(71,'Architecture.pdf',41,'http://192.168.43.107:5005/api/Document/FileAPI/17ba6c3e-0893-4069-8a53-13c81683c716Files.pdf','17ba6c3e-0893-4069-8a53-13c81683c716Files.pdf',NULL);
/*!40000 ALTER TABLE `mailAttachments` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `permisions`
--

DROP TABLE IF EXISTS `permisions`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `permisions` (
  `permisionId` int NOT NULL AUTO_INCREMENT,
  `permisionTitle` text,
  `create` tinyint(1) NOT NULL,
  `update` tinyint(1) NOT NULL,
  `Delete` tinyint(1) NOT NULL,
  `read` tinyint(1) NOT NULL,
  `userId` int NOT NULL,
  PRIMARY KEY (`permisionId`)
) ENGINE=InnoDB AUTO_INCREMENT=28 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `permisions`
--

LOCK TABLES `permisions` WRITE;
/*!40000 ALTER TABLE `permisions` DISABLE KEYS */;
INSERT INTO `permisions` VALUES (1,'superUser',1,1,1,1,1),(2,'manageMember',1,1,0,1,2),(3,'manageProjects',1,1,0,1,2),(4,'manageTasks',1,1,0,1,2),(5,'goalsManagement',1,1,0,1,2),(6,'managePermisions',1,1,0,1,2),(7,'manageRoles',1,1,0,1,2),(8,'manageUsers',1,1,0,1,2),(9,'manageReports',1,1,0,1,2),(10,'manageSettings',1,1,0,1,2),(11,'manageNotifications',1,1,0,1,2),(12,'manageCalendar',1,1,0,1,2),(13,'manageFiles',1,1,0,1,2),(14,'manageMessages',1,1,0,1,2),(15,'manageMember',0,0,0,1,3),(16,'manageProjects',0,0,0,1,3),(17,'manageTasks',0,0,0,1,3),(18,'goalsManagement',0,0,0,1,3),(19,'managePermisions',0,0,0,1,3),(20,'manageRoles',0,0,0,1,3),(21,'manageUsers',0,0,0,1,3),(22,'manageReports',0,0,0,1,3),(23,'manageSettings',0,0,0,1,3),(24,'manageNotifications',0,0,0,1,3),(25,'manageCalendar',0,0,0,1,3),(26,'manageFiles',0,0,0,1,3),(27,'manageMessages',0,0,0,1,3);
/*!40000 ALTER TABLE `permisions` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `projectDocument`
--

DROP TABLE IF EXISTS `projectDocument`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `projectDocument` (
  `documentId` int NOT NULL AUTO_INCREMENT,
  `documentName` varchar(30) DEFAULT NULL,
  `documentDescription` text,
  `documentStatus` text,
  `uploadBy` text,
  `documentVersion` text,
  `filePath` text,
  `sectionId` int NOT NULL,
  `projectId` int NOT NULL,
  `documentFileExtension` text,
  PRIMARY KEY (`documentId`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `projectDocument`
--

LOCK TABLES `projectDocument` WRITE;
/*!40000 ALTER TABLE `projectDocument` DISABLE KEYS */;
INSERT INTO `projectDocument` VALUES (1,'adsdas','asd','Approved','1','asdas','990e5888-bfdc-4593-966b-600dfceb8fdcFiles.json',1,1,'.json'),(2,'asdas','asdas','Approved','1','asdas','43616e4f-f106-47d3-a569-93fb1be0a1dfFiles.ttf',1,1,'.ttf'),(3,'asd','asd','Approved','1','asdas','240dcb86-0be6-4c4b-8ecd-88664755c2f6Files.docx',1,1,'.docx'),(4,'adas','asdas','Approved','1','asdas','3200e8e2-63e5-445c-baea-33f896dc7b2fFiles.mov',1,1,'.mov'),(5,'dsa','asd','Approved','1','asd','93fc9577-2b61-4a1a-a0f5-74cb0eb9449dFiles.xlsx',1,1,'.xlsx'),(6,'ada','asd','Approved','1','asd','9706f5c3-feda-4816-9feb-55225efcd0aaFiles.ppt',1,1,'.ppt'),(7,'asd','asd','Approved','1','asd','4be6f783-9b75-462f-886d-579aabfa3048Files.pdf',1,1,'.pdf'),(8,'asd','asd','Approved','1','asd','28a8d622-44ed-41a4-89eb-b0b2450ef6b9Files.pdf',1,1,'.pdf');
/*!40000 ALTER TABLE `projectDocument` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Projects`
--

DROP TABLE IF EXISTS `Projects`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Projects` (
  `pid` int NOT NULL AUTO_INCREMENT,
  `ProjectTitle` text,
  `projectDescription` text,
  `status` text,
  `progress` text,
  `CreateAt` date NOT NULL,
  `companyProject` text,
  `startDate` date NOT NULL,
  `endDate` date NOT NULL,
  PRIMARY KEY (`pid`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Projects`
--

LOCK TABLES `Projects` WRITE;
/*!40000 ALTER TABLE `Projects` DISABLE KEYS */;
INSERT INTO `Projects` VALUES (1,'asd','asd','On Track','0','2022-06-10','1','2022-06-11','2022-07-01');
/*!40000 ALTER TABLE `Projects` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ProjectTeams`
--

DROP TABLE IF EXISTS `ProjectTeams`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ProjectTeams` (
  `id` int NOT NULL AUTO_INCREMENT,
  `pid` int NOT NULL,
  `uid` int NOT NULL,
  `role` text,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ProjectTeams`
--

LOCK TABLES `ProjectTeams` WRITE;
/*!40000 ALTER TABLE `ProjectTeams` DISABLE KEYS */;
INSERT INTO `ProjectTeams` VALUES (1,1,1,'Product Owner'),(2,1,2,'Requirement Engineer'),(3,1,3,'Designer');
/*!40000 ALTER TABLE `ProjectTeams` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `QualitySchedule`
--

DROP TABLE IF EXISTS `QualitySchedule`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `QualitySchedule` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(30) NOT NULL,
  `start` datetime NOT NULL,
  `end` datetime NOT NULL,
  `dependancies` text,
  `AssignTo` int NOT NULL,
  `progress` int NOT NULL,
  `ProjectId` int NOT NULL,
  PRIMARY KEY (`id`),
  KEY `IX_QualitySchedule_ProjectId` (`ProjectId`),
  CONSTRAINT `FK_QualitySchedule_Projects_ProjectId` FOREIGN KEY (`ProjectId`) REFERENCES `Projects` (`pid`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `QualitySchedule`
--

LOCK TABLES `QualitySchedule` WRITE;
/*!40000 ALTER TABLE `QualitySchedule` DISABLE KEYS */;
/*!40000 ALTER TABLE `QualitySchedule` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `RequirementAttachments`
--

DROP TABLE IF EXISTS `RequirementAttachments`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `RequirementAttachments` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` text,
  `requirementId` int NOT NULL,
  `AttachmentPath` text,
  `AttachmentExtension` text,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `RequirementAttachments`
--

LOCK TABLES `RequirementAttachments` WRITE;
/*!40000 ALTER TABLE `RequirementAttachments` DISABLE KEYS */;
INSERT INTO `RequirementAttachments` VALUES (1,'240dcb86-0be6-4c4b-8ecd-88664755c2f6Files.docx',1,'4a4d9c25-2fa6-43c1-a88b-26111454c2e3Files.docx','.docx');
/*!40000 ALTER TABLE `RequirementAttachments` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `requirements`
--

DROP TABLE IF EXISTS `requirements`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `requirements` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(30) NOT NULL,
  `status` text,
  `requirementDescription` text,
  `requirementType` text,
  `modifiedBy` text,
  `modifeidOn` date NOT NULL,
  `moduleId` int NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `requirements`
--

LOCK TABLES `requirements` WRITE;
/*!40000 ALTER TABLE `requirements` DISABLE KEYS */;
INSERT INTO `requirements` VALUES (1,'User Requirement ','New','This IS user Rewuirement ','user based','2','2022-06-12',1);
/*!40000 ALTER TABLE `requirements` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `RequirementsModule`
--

DROP TABLE IF EXISTS `RequirementsModule`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `RequirementsModule` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` text,
  `status` text,
  `modifiedBy` text,
  `modifeidOn` date NOT NULL,
  `projectId` int NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `RequirementsModule`
--

LOCK TABLES `RequirementsModule` WRITE;
/*!40000 ALTER TABLE `RequirementsModule` DISABLE KEYS */;
INSERT INTO `RequirementsModule` VALUES (1,'App Requirement','Pakistan','2','2022-06-12',1);
/*!40000 ALTER TABLE `RequirementsModule` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Schedule`
--

DROP TABLE IF EXISTS `Schedule`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Schedule` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(30) NOT NULL,
  `start` datetime NOT NULL,
  `end` datetime NOT NULL,
  `dependancies` text,
  `AssignTo` int NOT NULL,
  `progress` int NOT NULL,
  `ProjectId` int NOT NULL,
  PRIMARY KEY (`id`),
  KEY `IX_Schedule_ProjectId` (`ProjectId`),
  CONSTRAINT `FK_Schedule_Projects_ProjectId` FOREIGN KEY (`ProjectId`) REFERENCES `Projects` (`pid`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Schedule`
--

LOCK TABLES `Schedule` WRITE;
/*!40000 ALTER TABLE `Schedule` DISABLE KEYS */;
INSERT INTO `Schedule` VALUES (1,'Sqp','2022-06-08 00:00:00','2022-06-09 00:00:00','',1,39,1),(2,'asd','2022-06-30 00:00:00','2022-07-09 00:00:00','1',1,0,1);
/*!40000 ALTER TABLE `Schedule` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `SubTasks`
--

DROP TABLE IF EXISTS `SubTasks`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `SubTasks` (
  `taskid` int NOT NULL AUTO_INCREMENT,
  `taskTitle` text,
  `startDate` date NOT NULL,
  `endDate` date NOT NULL,
  `description` text,
  `status` text,
  `progress` text,
  `CreateAt` date NOT NULL,
  PRIMARY KEY (`taskid`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `SubTasks`
--

LOCK TABLES `SubTasks` WRITE;
/*!40000 ALTER TABLE `SubTasks` DISABLE KEYS */;
/*!40000 ALTER TABLE `SubTasks` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Tasks`
--

DROP TABLE IF EXISTS `Tasks`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Tasks` (
  `tid` int NOT NULL AUTO_INCREMENT,
  `TaskTitle` text,
  `ProjectId` int NOT NULL,
  `startDate` datetime NOT NULL,
  `endDate` date NOT NULL,
  `description` text,
  `status` text,
  `progress` text,
  `CreateAt` date NOT NULL,
  `TaskCost` text,
  PRIMARY KEY (`tid`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Tasks`
--

LOCK TABLES `Tasks` WRITE;
/*!40000 ALTER TABLE `Tasks` DISABLE KEYS */;
/*!40000 ALTER TABLE `Tasks` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `TestCaseAttachment`
--

DROP TABLE IF EXISTS `TestCaseAttachment`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `TestCaseAttachment` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` text,
  `testresultId` int NOT NULL,
  `AttachmentPath` text,
  `AttachmentExtension` text,
  `AtttachmentType` text,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `TestCaseAttachment`
--

LOCK TABLES `TestCaseAttachment` WRITE;
/*!40000 ALTER TABLE `TestCaseAttachment` DISABLE KEYS */;
INSERT INTO `TestCaseAttachment` VALUES (1,'arch-diagram_nodejs-app.4c8966fcddcba4e101b955905cf88d99d4c9dcd5.png',1,'310af6fd-0e62-449a-b664-200546453b6dFiles.png','.png','ExpectedOutcome'),(2,'flobroLOGO.png',1,'a70f32bd-ebe6-4239-9076-7449cdee4cc3Files.png','.png','testOutCome'),(3,'flobroLOGO.png',2,'36147b19-9c94-4adc-8d78-a2f26aab280dFiles.png','.png','ExpectedOutcome'),(4,'gmail.jpeg',2,'030574d6-ce76-49a8-bf9c-52a866e006fbFiles.jpeg','.jpeg','testOutCome'),(5,'flobroLOGO.png',3,'7688fe3e-8bd9-44cc-b2f5-43637bc656caFiles.png','.png','ExpectedOutcome'),(6,'9597f37a-59bc-4449-8b8b-d4797643f85fFiles.pdf',3,'3cb077cd-9e2f-497a-8499-d1ac239145c0Files.pdf','.pdf','testOutCome'),(7,'Screen Recording 2022-06-11 at 2.13.52 PM.mov',4,'5aa041b3-5e79-4b29-ba36-88e350fa0011Files.mov','.mov','ExpectedOutcome'),(8,'gmail.jpeg',4,'85a3d325-5496-452a-9450-c1e9d39ed02fFiles.jpeg','.jpeg','testOutCome'),(9,'9597f37a-59bc-4449-8b8b-d4797643f85fFiles.pdf',5,'666a283c-353c-4e4e-8a37-b96714f8462eFiles.pdf','.pdf','ExpectedOutcome'),(10,'AzeemSarwar.pdf',5,'4167f240-f1f7-4698-8160-01b50f41f787Files.pdf','.pdf','testOutCome');
/*!40000 ALTER TABLE `TestCaseAttachment` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `testCases`
--

DROP TABLE IF EXISTS `testCases`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `testCases` (
  `id` int NOT NULL AUTO_INCREMENT,
  `Name` text,
  `categoryName` text,
  `categoryType` text,
  `testType` text,
  `testPlanId` int NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `testCases`
--

LOCK TABLES `testCases` WRITE;
/*!40000 ALTER TABLE `testCases` DISABLE KEYS */;
INSERT INTO `testCases` VALUES (1,'Test Auth Screen','Auth Validation','Test Auth Validation','Validation',1),(2,'Dashboard','Dashboard','Dashboard','dashBoard',1),(3,'test','test','test','test',1);
/*!40000 ALTER TABLE `testCases` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `testPlan`
--

DROP TABLE IF EXISTS `testPlan`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `testPlan` (
  `id` int NOT NULL AUTO_INCREMENT,
  `Name` text,
  `Description` text,
  `EnvId` int NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `testPlan`
--

LOCK TABLES `testPlan` WRITE;
/*!40000 ALTER TABLE `testPlan` DISABLE KEYS */;
INSERT INTO `testPlan` VALUES (1,'Test Work plan','Here We defince Test Work Plan',1);
/*!40000 ALTER TABLE `testPlan` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `testResult`
--

DROP TABLE IF EXISTS `testResult`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `testResult` (
  `id` int NOT NULL AUTO_INCREMENT,
  `Description` text,
  `testId` int NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `testResult`
--

LOCK TABLES `testResult` WRITE;
/*!40000 ALTER TABLE `testResult` DISABLE KEYS */;
INSERT INTO `testResult` VALUES (1,'How it will lok like',1),(2,'description of testcase',2),(3,'test',3),(4,'sdsds',3),(5,'vxvc',3);
/*!40000 ALTER TABLE `testResult` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Users`
--

DROP TABLE IF EXISTS `Users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Users` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(30) DEFAULT NULL,
  `password` text,
  `userName` text,
  `email` text,
  `profilePic` text,
  `phone` text,
  `Lastlogin` date NOT NULL,
  `role` text,
  `onlineStatus` text,
  `companyId` text,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Users`
--

LOCK TABLES `Users` WRITE;
/*!40000 ALTER TABLE `Users` DISABLE KEYS */;
INSERT INTO `Users` VALUES (1,'Azeem','$2a$11$teJQy42bpqwrQgUSqH.e/.dGxX4Omc7i2agTiAL4UwmjkvmNnZW9u','as1265513@uiit.pa.com','as1265513@gmail.com',NULL,'923829101112','0001-01-01','admin',NULL,'1'),(2,'rehan','$2a$11$FmjPdDxxIOrmJeo20R8pPezYE03L2xAgifV/IOwBS0mXTNsY39gDG','rehan@uiit.pa.com','rehan@gmail.com',NULL,'927362738628','0001-01-01','Moderator',NULL,'1'),(3,'test','$2a$11$Un2NEPRt1Q1LAuRXect7vOQXv2Wd.ePGACCDiJN1mKceVJwvkLmBu','test@uiit.pa.com','test@gmail.com',NULL,'32092389203','0001-01-01','Member',NULL,'1');
/*!40000 ALTER TABLE `Users` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2022-06-13 12:23:01
