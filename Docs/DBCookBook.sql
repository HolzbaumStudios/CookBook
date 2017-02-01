

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `nicoleu1_DBCookBook`
--
CREATE DATABASE IF NOT EXISTS `DBCookBook` DEFAULT CHARACTER SET latin1 COLLATE latin1_swedish_ci;
USE `DBCookBook`;

-- --------------------------------------------------------

--
-- Table structure for table `IMAGES`
--

CREATE TABLE IF NOT EXISTS `IMAGES` (
  `id_images` int(11) NOT NULL AUTO_INCREMENT,
  `storage_path` varchar(255) NOT NULL,
  PRIMARY KEY (`id_images`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=4 ;

--
-- Dumping data for table `IMAGES`
--

INSERT INTO `IMAGES` (`id_images`, `storage_path`) VALUES
(1, ''),
(2, ''),
(3, '');

-- --------------------------------------------------------

--
-- Table structure for table `INGREDIENTS`
--

CREATE TABLE IF NOT EXISTS `INGREDIENTS` (
  `id_ingredients` int(11) NOT NULL AUTO_INCREMENT,
  `ingredients_name` varchar(45) NOT NULL,
  PRIMARY KEY (`id_ingredients`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=55 ;

--
-- Dumping data for table `INGREDIENTS`
--

INSERT INTO `INGREDIENTS` (`id_ingredients`, `ingredients_name`) VALUES
(46, 'Salz'),
(47, 'Pasta'),
(48, 'Ei'),
(49, 'Parmesan'),
(50, 'Butter'),
(53, 'Eier');

-- --------------------------------------------------------

--
-- Table structure for table `QUANTITYUNITS`
--

CREATE TABLE IF NOT EXISTS `QUANTITYUNITS` (
  `id_quantityunits` int(11) NOT NULL AUTO_INCREMENT,
  `quantityunits_name` varchar(45) NOT NULL,
  PRIMARY KEY (`id_quantityunits`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=11 ;

--
-- Dumping data for table `QUANTITYUNITS`
--

INSERT INTO `QUANTITYUNITS` (`id_quantityunits`, `quantityunits_name`) VALUES
(1, 'g'),
(4, 'mg'),
(5, 'kg'),
(6, 'ml'),
(7, 'cl'),
(8, 'dl'),
(9, 'l'),
(10, 'st');

-- --------------------------------------------------------

--
-- Table structure for table `RECIPES`
--

CREATE TABLE IF NOT EXISTS `RECIPES` (
  `id_recipes` int(11) NOT NULL AUTO_INCREMENT,
  `recipes_name` varchar(45) NOT NULL,
  `recipes_description` varchar(500) DEFAULT NULL,
  `recipes_creator` varchar(45) DEFAULT NULL,
  `fk_image` int(11) NOT NULL,
  PRIMARY KEY (`id_recipes`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=48 ;

--
-- Dumping data for table `RECIPES`
--

INSERT INTO `RECIPES` (`id_recipes`, `recipes_name`, `recipes_description`, `recipes_creator`, `fk_image`) VALUES
(39, 'Pasta mit Wienerli', 'Eine köstliches Gericht mit den einfachsten Zutaten.', 'SirWoody', 0),
(40, 'Omelette Souffle', 'Ein exquisites Omelette, welche wie Schaum im Mund zergeht.', 'Woku', 0);

-- --------------------------------------------------------

--
-- Table structure for table `RECIPES_STEPS`
--

CREATE TABLE IF NOT EXISTS `RECIPES_STEPS` (
  `id_recipes_steps` int(11) NOT NULL AUTO_INCREMENT,
  `fk_recipes` int(11) NOT NULL,
  `fk_steps` int(11) NOT NULL,
  `step_order` int(11) NOT NULL,
  PRIMARY KEY (`id_recipes_steps`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=72 ;

--
-- Dumping data for table `RECIPES_STEPS`
--

INSERT INTO `RECIPES_STEPS` (`id_recipes_steps`, `fk_recipes`, `fk_steps`, `step_order`) VALUES
(60, 39, 58, 1),
(61, 39, 59, 2),
(62, 39, 60, 3),
(63, 40, 61, 1),
(64, 40, 62, 2),
(65, 40, 63, 3),
(66, 40, 64, 4),
(67, 40, 65, 5),
(68, 40, 66, 6),
(69, 44, 67, 1),
(70, 46, 69, 1),
(71, 47, 70, 1);

-- --------------------------------------------------------

--
-- Table structure for table `RECIPES_TAGS`
--

CREATE TABLE IF NOT EXISTS `RECIPES_TAGS` (
  `id_recipes_tags` int(11) NOT NULL AUTO_INCREMENT,
  `fk_recipes` int(11) NOT NULL,
  `fk_tags` int(11) NOT NULL,
  PRIMARY KEY (`id_recipes_tags`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=37 ;

--
-- Dumping data for table `RECIPES_TAGS`
--

INSERT INTO `RECIPES_TAGS` (`id_recipes_tags`, `fk_recipes`, `fk_tags`) VALUES
(26, 39, 36),
(27, 39, 37),
(28, 40, 38),
(29, 40, 39),
(30, 40, 40),
(31, 41, 51),
(32, 42, 52),
(33, 43, 60),
(34, 44, 71),
(35, 46, 73),
(36, 47, 74);

-- --------------------------------------------------------

--
-- Table structure for table `STEPS`
--

CREATE TABLE IF NOT EXISTS `STEPS` (
  `id_steps` int(11) NOT NULL AUTO_INCREMENT,
  `steps_description` varchar(1000) NOT NULL,
  `steps_timer` int(11) DEFAULT NULL,
  `fk_image` int(11) DEFAULT NULL,
  PRIMARY KEY (`id_steps`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=71 ;

--
-- Dumping data for table `STEPS`
--

INSERT INTO `STEPS` (`id_steps`, `steps_description`, `steps_timer`, `fk_image`) VALUES
(58, 'Die Wienerli in kleine Rädchen schneiden.', 0, 1),
(59, 'Das Wasser aufkochen und etwas Salz dazu geben.', 300, 1),
(60, 'Pasta hineinwerfen und warten bis es aufgekocht ist.', 480, 1);

-- --------------------------------------------------------

--
-- Table structure for table `STEPS_INGREDIENTS`
--

CREATE TABLE IF NOT EXISTS `STEPS_INGREDIENTS` (
  `id_steps_ingredients` int(11) NOT NULL AUTO_INCREMENT,
  `fk_steps` int(11) NOT NULL,
  `fk_ingredients` int(11) NOT NULL,
  `fk_quantityunits` int(11) NOT NULL,
  `quantity` int(11) NOT NULL,
  PRIMARY KEY (`id_steps_ingredients`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=3 ;

-- --------------------------------------------------------

--
-- Table structure for table `TAGS`
--

CREATE TABLE IF NOT EXISTS `TAGS` (
  `id_tags` int(11) NOT NULL AUTO_INCREMENT,
  `tags_name` varchar(45) NOT NULL,
  PRIMARY KEY (`id_tags`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=75 ;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
