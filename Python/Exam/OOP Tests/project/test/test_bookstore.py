import unittest

from project.bookstore import Bookstore


class BookstoreTests(unittest.TestCase):
    valid_size = 1000
    invalid_size = -1

    def setUp(self) -> None:
        self.bookstore = Bookstore(self.valid_size)

    def test_init__when_books_limit_is_valid_expect_correct_values(self):
        self.assertEqual(self.valid_size, self.bookstore.books_limit)
        self.assertDictEqual({}, self.bookstore.availability_in_store_by_book_titles)

    def test_books_limit_prop__when_value_is_0__expect_correct(self):
        bookstore = Bookstore(self.valid_size)
        bookstore.books_limit = self.valid_size + 1

        self.assertEqual(bookstore.books_limit, self.valid_size + 1)

    def test_books_limit_prop__when_value_is_negative__expect_to_raise(self):
        with self.assertRaises(ValueError) as context:
            self.bookstore.books_limit = self.invalid_size

        self.assertIsNotNone(context.exception)
        self.assertEqual('Books limit of -1 is not valid', str(context.exception))
        self.assertEqual(self.valid_size, self.bookstore.books_limit)

    def test_total_sold_books_with_no_sells(self):
        self.assertEqual(0, self.bookstore.total_sold_books)

    def test_books_limit_prop__when_value_is_0__expect_to_raise(self):
        with self.assertRaises(ValueError) as context:
            self.bookstore.books_limit = 0

        self.assertIsNotNone(context.exception)
        self.assertEqual('Books limit of 0 is not valid', str(context.exception))
        self.assertEqual(self.valid_size, self.bookstore.books_limit)

    def test_second_books_limit_prop__when_value_is_0__expect_to_raise(self):
        with self.assertRaises(ValueError) as context:
            bookstore = Bookstore(0)

        self.assertIsNotNone(context.exception)
        self.assertEqual('Books limit of 0 is not valid', str(context.exception))

    def test_len_property(self):
        self.bookstore.receive_book('TestBook', 10)
        self.bookstore.receive_book('TestBook2', 15)

        self.assertEqual(len(self.bookstore), 25)

    def test_receive_book_over_limit_should_raise(self):
        with self.assertRaises(Exception) as context:
            bookstore = Bookstore(1)
            bookstore.receive_book('Book1', 1)
            bookstore.receive_book('Book2', 2)

        self.assertIsNotNone(context.exception)
        self.assertEqual('Books limit is reached. Cannot receive more books!', str(context.exception))
        self.assertDictEqual({'Book1': 1}, bookstore.availability_in_store_by_book_titles)

    def test_receive_book_enough_space(self):
        self.bookstore.receive_book('TestTitle', 5)
        self.bookstore.receive_book('TestTitle2', 40)

        self.assertDictEqual({'TestTitle': 5, 'TestTitle2': 40}, self.bookstore.availability_in_store_by_book_titles)

    def test_receive_book_returns_correctly(self):
        self.bookstore.receive_book('TestTitle2', 40)
        self.bookstore.receive_book('TestTitle', 5)
        result = self.bookstore.receive_book('TestTitle', 5)

        self.assertEqual('10 copies of TestTitle are available in the bookstore.', result)
        self.assertDictEqual({'TestTitle': 10, 'TestTitle2': 40}, self.bookstore.availability_in_store_by_book_titles)
        self.assertEqual(self.bookstore.availability_in_store_by_book_titles['TestTitle'], 10)
        self.assertEqual(len(self.bookstore), 50)

    def test_sell_book_raises_if_book_not_available(self):
        with self.assertRaises(Exception) as context:
            bookstore = Bookstore(5)
            bookstore.sell_book('MissingBook', 2)

        self.assertIsNotNone(context.exception)
        self.assertEqual("Book MissingBook doesn't exist!", str(context.exception))

    def test_sell_book_raises_if_book_not_enough(self):
        with self.assertRaises(Exception) as context:
            bookstore = Bookstore(5)
            bookstore.receive_book('TestBook', 3)
            bookstore.sell_book('TestBook', 5)

        self.assertIsNotNone(context.exception)
        self.assertEqual("TestBook has not enough copies to sell. Left: 3", str(context.exception))
        self.assertDictEqual({'TestBook': 3}, bookstore.availability_in_store_by_book_titles)

    def test_sell_book_works_correctly(self):
        bookstore = Bookstore(50)
        bookstore.receive_book('Test', 10)
        bookstore.sell_book('Test', 10)
        bookstore.receive_book('TestBook', 10)
        result = bookstore.sell_book('TestBook', 5)

        self.assertEqual(bookstore.availability_in_store_by_book_titles['TestBook'], 5)
        self.assertEqual(bookstore.availability_in_store_by_book_titles['Test'], 0)
        self.assertEqual(bookstore.total_sold_books, 15)
        self.assertEqual("Sold 5 copies of TestBook", result)
        self.assertDictEqual({'Test': 0, 'TestBook': 5}, bookstore.availability_in_store_by_book_titles)

    def test_str_returns_correctly(self):
        bookstore = Bookstore(50)
        bookstore.receive_book('TestBook', 10)
        bookstore.sell_book('TestBook', 5)
        result = str(bookstore)

        self.assertEqual(result, "Total sold books: 5\nCurrent availability: 5\n - TestBook: 5 copies")
