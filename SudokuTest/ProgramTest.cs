using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sudoku;
using System.IO;

namespace SudokuTest
{
    [TestClass]
    public class ProgramTest
    {
        int[,] arrayValid = new int[9, 9]{
        {5,3,4,6,7,8,9,1,2},
        {6,7,2,1,9,5,3,4,8},
        {1,9,8,3,4,2,5,6,7},
        {8,5,9,7,6,1,4,2,3},
        {4,2,6,8,5,3,7,9,1},
        {7,1,3,9,2,4,8,5,6},
        {9,6,1,5,3,7,2,8,4},
        {2,8,7,4,1,9,6,3,5},
        {3,4,5,2,8,6,1,7,9}};

        int[,] arrayInvalidColumns = new int[9, 9]{
        {1,2,3,4,5,6,7,8,9},
        {1,2,3,4,5,6,7,8,9},
        {1,2,3,4,5,6,7,8,9},
        {1,2,3,4,5,6,7,8,9},
        {1,2,3,4,5,6,7,8,9},
        {1,2,3,4,5,6,7,8,9},
        {1,2,3,4,5,6,7,8,9},
        {1,2,3,4,5,6,7,8,9},
        {1,2,3,4,5,6,7,8,9}};

        int[,] arrayInvalid = new int[9, 9]{
        {7,7,7,6,7,8,9,1,2},
        {6,7,2,1,9,5,3,4,8},
        {1,9,8,3,4,2,5,6,7},
        {8,5,9,7,6,1,4,2,3},
        {4,2,6,8,5,3,7,9,1},
        {7,1,3,9,2,4,8,5,6},
        {9,6,1,5,3,7,2,8,4},
        {2,8,7,4,1,9,6,3,5},
        {3,4,5,2,8,6,1,7,9}};




        [TestMethod]
        public void IsValid_True()
        {
            int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9};

            bool expected = true;
            bool actual = SudokuValidate.IsValid(array);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IsValid_False()
        {
            int[] array = { 1, 1, 3, 4, 5, 6, 7, 8, 9 };

            bool expected = false;
            bool actual = SudokuValidate.IsValid(array);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ValidateRows_With_Valid_Array()
        {
            SudokuValidate sudoku = new SudokuValidate(arrayValid);
            bool expected = true;
            bool actual = sudoku.ValidateRows();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ValidateColumns_With_Valid_Array()
        {
            SudokuValidate sudoku = new SudokuValidate(arrayValid);
            bool expected = true;
            bool actual = sudoku.ValidateColumns();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ValidateSquares_With_Valid_Array()
        {
            SudokuValidate sudoku = new SudokuValidate(arrayValid);
            bool expected = true;
            bool actual = sudoku.ValidateSquares();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ValidateRows_With_Invalid_Columns()
        {
            SudokuValidate sudoku = new SudokuValidate(arrayInvalidColumns);
            bool expected = true;
            bool actual = sudoku.ValidateRows();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ValidateColumns_With_Invalid_Columns()
        {
            SudokuValidate sudoku = new SudokuValidate(arrayInvalidColumns);
            bool expected = false;
            bool actual = sudoku.ValidateColumns();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ValidateSquares_With_Invalid_Columns()
        {
            SudokuValidate sudoku = new SudokuValidate(arrayInvalidColumns);
            bool expected = false;
            bool actual = sudoku.ValidateSquares();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ValidateRows_With_Invalid_Array()
        {
            SudokuValidate sudoku = new SudokuValidate(arrayInvalid);
            bool expected = false;
            bool actual = sudoku.ValidateRows();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ValidateColumns_With_Invalid_Array()
        {
            SudokuValidate sudoku = new SudokuValidate(arrayInvalid);
            bool expected = false;
            bool actual = sudoku.ValidateColumns();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ValidateSquares_With_Invalid_Array()
        {
            SudokuValidate sudoku = new SudokuValidate(arrayInvalid);
            bool expected = false;
            bool actual = sudoku.ValidateSquares();
            Assert.AreEqual(expected, actual);
        }
    }
}
