-- phpMyAdmin SQL Dump
-- version 5.0.2
-- https://www.phpmyadmin.net/
--
-- Hôte : 127.0.0.1:3306
-- Généré le : mar. 31 mai 2022 à 12:54
-- Version du serveur :  5.7.31
-- Version de PHP : 7.3.21

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données : `restaurant`
--

-- --------------------------------------------------------

--
-- Structure de la table `command`
--

DROP TABLE IF EXISTS `command`;
CREATE TABLE IF NOT EXISTS `command` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `commandDate` date NOT NULL,
  `commandTable` int(11) NOT NULL,
  `idStarter` int(11) NOT NULL,
  `idMeal` int(11) NOT NULL,
  `idDessert` int(11) NOT NULL,
  `idDrink` int(11) NOT NULL,
  `stateStarter` varchar(50) NOT NULL,
  `stateMeal` varchar(50) NOT NULL,
  `stateDessert` varchar(50) NOT NULL,
  `stateDrink` varchar(50) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=16 DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `command`
--

INSERT INTO `command` (`id`, `commandDate`, `commandTable`, `idStarter`, `idMeal`, `idDessert`, `idDrink`, `stateStarter`, `stateMeal`, `stateDessert`, `stateDrink`) VALUES
(12, '2022-05-31', 2, 2, 2, 2, 2, 'Servi', 'En attente', 'En attente', 'En attente'),
(9, '2022-05-26', 9, 2, 2, 2, 2, 'Servi', 'Servi', 'Servi', 'Servi');

-- --------------------------------------------------------

--
-- Structure de la table `dessert`
--

DROP TABLE IF EXISTS `dessert`;
CREATE TABLE IF NOT EXISTS `dessert` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `label` varchar(50) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `dessert`
--

INSERT INTO `dessert` (`id`, `label`) VALUES
(1, 'Tarte aux pommes'),
(2, 'Tarte aux citrons');

-- --------------------------------------------------------

--
-- Structure de la table `drink`
--

DROP TABLE IF EXISTS `drink`;
CREATE TABLE IF NOT EXISTS `drink` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `label` varchar(50) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `drink`
--

INSERT INTO `drink` (`id`, `label`) VALUES
(1, 'Coca-Cola'),
(2, 'Fanta');

-- --------------------------------------------------------

--
-- Structure de la table `meal`
--

DROP TABLE IF EXISTS `meal`;
CREATE TABLE IF NOT EXISTS `meal` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `label` varchar(50) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `meal`
--

INSERT INTO `meal` (`id`, `label`) VALUES
(1, 'Lasagnes au pesto'),
(2, 'Pâtes aux 4 fromages ');

-- --------------------------------------------------------

--
-- Structure de la table `starter`
--

DROP TABLE IF EXISTS `starter`;
CREATE TABLE IF NOT EXISTS `starter` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `label` varchar(50) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `starter`
--

INSERT INTO `starter` (`id`, `label`) VALUES
(1, 'Salade '),
(2, 'Radis ');
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
