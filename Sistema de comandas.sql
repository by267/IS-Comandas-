-- MySQL dump 10.13  Distrib 8.0.36, for Win64 (x86_64)
--
-- Host: localhost    Database: comandas
-- ------------------------------------------------------
-- Server version	8.0.36

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
-- Table structure for table `categorias`
--

DROP TABLE IF EXISTS `categorias`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `categorias` (
  `idCategorias` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`idCategorias`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `categorias`
--

LOCK TABLES `categorias` WRITE;
/*!40000 ALTER TABLE `categorias` DISABLE KEYS */;
INSERT INTO `categorias` VALUES (1,'Bebidas'),(3,'Comida'),(6,'Entradas'),(7,'Postres');
/*!40000 ALTER TABLE `categorias` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `comandas`
--

DROP TABLE IF EXISTS `comandas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `comandas` (
  `idComandas` int NOT NULL AUTO_INCREMENT,
  `producto` varchar(45) DEFAULT NULL,
  `precio` float DEFAULT NULL,
  `cantidad` int DEFAULT NULL,
  `mesa` int DEFAULT NULL,
  `comentarios` varchar(45) DEFAULT NULL,
  `noComanda` int DEFAULT NULL,
  `noCuenta` int DEFAULT NULL,
  PRIMARY KEY (`idComandas`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `comandas`
--

LOCK TABLES `comandas` WRITE;
/*!40000 ALTER TABLE `comandas` DISABLE KEYS */;
/*!40000 ALTER TABLE `comandas` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cuenta`
--

DROP TABLE IF EXISTS `cuenta`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `cuenta` (
  `idCuenta` int NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`idCuenta`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cuenta`
--

LOCK TABLES `cuenta` WRITE;
/*!40000 ALTER TABLE `cuenta` DISABLE KEYS */;
/*!40000 ALTER TABLE `cuenta` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `empleados`
--

DROP TABLE IF EXISTS `empleados`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `empleados` (
  `idEmpleado` int NOT NULL AUTO_INCREMENT,
  `NombreCompleto` varchar(45) DEFAULT NULL,
  `Usuario` varchar(45) DEFAULT NULL,
  `Password` varchar(45) DEFAULT NULL,
  `Puesto` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`idEmpleado`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `empleados`
--

LOCK TABLES `empleados` WRITE;
/*!40000 ALTER TABLE `empleados` DISABLE KEYS */;
INSERT INTO `empleados` VALUES (5,'Oscar Ivan Perez Brambila','by267','1234','Gerente'),(7,'Soe Lizarraga','soe','1234','Cajero'),(8,'Veronica Amezcua','veroame','abc123','Mesero');
/*!40000 ALTER TABLE `empleados` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `menu`
--

DROP TABLE IF EXISTS `menu`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `menu` (
  `idMenu` int NOT NULL AUTO_INCREMENT,
  `Nombre` varchar(45) DEFAULT NULL,
  `Descripcion` varchar(45) DEFAULT NULL,
  `Precio` float DEFAULT NULL,
  `categoria` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`idMenu`)
) ENGINE=InnoDB AUTO_INCREMENT=24 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `menu`
--

LOCK TABLES `menu` WRITE;
/*!40000 ALTER TABLE `menu` DISABLE KEYS */;
INSERT INTO `menu` VALUES (3,'Hamburguesa','Mediana',99.8,'Comida'),(4,'Papas','Chicas',55.9,'Comida'),(5,'Helado','Chico',59,'Postres'),(6,'Sundae','Mediano',69,'Postres'),(7,'Pastel','Rebanada de pastel chica',65,'Postres'),(8,'CocaCola','600ml',25,'Bebidas'),(9,'Agua de horchata','500ml',20,'Bebidas'),(10,'Agua de horchata de fresa','500ml',20,'Bebidas'),(11,'Agua de jamaica','500ml',20,'Bebidas'),(12,'Agua Natural','1l',20,'Bebidas'),(13,'Agua Mineral','500ml',23,'Bebidas'),(14,'Cafe','330ml',22,'Bebidas'),(15,'Bistec','Acompañado de frijol',99,'Comida'),(16,'Charron','Acompañado de frijoles',100,'Comida'),(17,'Choripapa','Choripapa con frijoles',95,'Comida'),(18,'Huevos divorciados','Acompañadp de frijoles',85,'Comida'),(19,'Chilaquiles verdes','Acompañados con queso y frijoles',85,'Comida'),(20,'Flan napolitano','Napolitano',35,'Postres'),(21,'Pan dulce','Variedad de panes dulces',45,'Postres'),(22,'Dulce de leche','Especial de la casa',15,'Postres'),(23,'Camarones empanizados','Orden completa',200,'Comida');
/*!40000 ALTER TABLE `menu` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `mesas`
--

DROP TABLE IF EXISTS `mesas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `mesas` (
  `idmesas` int NOT NULL AUTO_INCREMENT,
  `estado` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`idmesas`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `mesas`
--

LOCK TABLES `mesas` WRITE;
/*!40000 ALTER TABLE `mesas` DISABLE KEYS */;
INSERT INTO `mesas` VALUES (1,'off'),(2,'off'),(3,'off'),(4,'off'),(5,'off'),(6,'on'),(7,'off'),(8,'off'),(12,'off');
/*!40000 ALTER TABLE `mesas` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ticket`
--

DROP TABLE IF EXISTS `ticket`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ticket` (
  `idTicket` int NOT NULL AUTO_INCREMENT,
  `listProd` longtext,
  `total` float DEFAULT NULL,
  `ingreso` float DEFAULT NULL,
  `cambio` float DEFAULT NULL,
  PRIMARY KEY (`idTicket`)
) ENGINE=InnoDB AUTO_INCREMENT=49 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ticket`
--

LOCK TABLES `ticket` WRITE;
/*!40000 ALTER TABLE `ticket` DISABLE KEYS */;
INSERT INTO `ticket` VALUES (1,'System.Collections.Generic.List`1[IS_Comandas_.Cajero.ticket]',260.16,NULL,NULL),(2,'System.Collections.Generic.List`1[IS_Comandas_.Cajero.ticket]',260.16,NULL,NULL),(3,'IS_Comandas_.Cajero.ticket, IS_Comandas_.Cajero.ticket',260.16,NULL,NULL),(4,'IS_Comandas_.Cajero.ticket, IS_Comandas_.Cajero.ticket',238.48,NULL,NULL),(5,'Id: 0 Producto: Hamburguesa Precio: 0Id: 0 Producto: Papas Precio: 0',238.48,NULL,NULL),(6,'Producto: HamburguesaProducto: Papas',238.48,NULL,NULL),(7,' Hamburguesa Papas',260.16,NULL,NULL),(8,' Hamburguesa, Papas,',260.16,NULL,NULL),(13,' Hamburguesa, Papas,',249.32,NULL,NULL),(14,' Hamburguesa, Papas,',271,NULL,NULL),(15,' Hamburguesa, Papas,',249.32,NULL,NULL),(16,' Hamburguesa, Papas,',238.48,NULL,NULL),(17,' Hamburguesa, Papas,',171.27,NULL,NULL),(19,' Hamburguesa, Papas, Papas, Hamburguesa, Papas, Papas,',3482.71,NULL,NULL),(20,' Hamburguesa, Papas, Papas, Hamburguesa, Papas, Papas,',3799.32,NULL,NULL),(21,' Hamburguesa, Papas, Papas, Hamburguesa, Papas, Papas,',3799.32,NULL,NULL),(24,' Hamburguesa, Papas, Papas, Hamburguesa, Papas, Papas,',3482.71,0,0),(25,' Hamburguesa, Papas, Papas, Hamburguesa, Papas, Papas,',3482.71,0,0),(26,' Hamburguesa, Papas, Papas, Hamburguesa, Papas, Papas,',3799.32,0,0),(27,' Hamburguesa, Papas, Papas, Hamburguesa, Papas, Papas,',3482.71,0,0),(28,' Hamburguesa, Papas, Papas, Hamburguesa, Papas, Papas,',3641.02,0,0),(29,' Hamburguesa, Papas, Papas, Hamburguesa, Papas, Papas,',3672.68,5000,1327.32),(30,' Hamburguesa, Papas, Papas, Hamburguesa, Papas, Papas,',3482.71,4000,517.29),(31,' Hamburguesa, Papas, Papas, Hamburguesa, Papas, Papas,',3641.02,4000,358.985),(32,' Hamburguesa, Papas, Papas, Hamburguesa, Papas, Papas,',3577.69,4000,422.307),(33,' Hamburguesa, Papas, Papas, Hamburguesa, Papas, Papas,',3482.71,3500,17.2898),(34,' Hamburguesa, Papas, Papas, Hamburguesa, Papas, Papas,',3641.02,4000,358.985),(35,' asd,',6.9,10,3.1),(36,' asd,',13.2,15,1.8),(37,' Hamburguesa,',229.54,300,70.46),(38,' Papas, Hamburguesa,',294.25,400,105.75),(39,' Papas, Hamburguesa,',321,400,79),(40,' Papas, Hamburguesa,',312.975,400,87.025),(41,' Papas, Hamburguesa,',329.025,400,70.975),(42,' Papas, Hamburguesa,',299.6,400,100.4),(43,' Papas, Hamburguesa,',302.275,350,47.725),(44,' Papas, Hamburguesa,',294.25,300,5.75),(45,' Papas, Hamburguesa,',294.25,300,5.75),(46,' Papas, Hamburguesa,',307.625,350,42.375),(47,' Papas, Hamburguesa,',302.275,350,47.725),(48,' Camarones empanizados, Papas,',562.98,1000,437.02);
/*!40000 ALTER TABLE `ticket` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-05-17 20:34:10
