import unittest

from project.plantation import Plantation


class PlantationTests(unittest.TestCase):
    valid_size = 5000
    invalid_size = -1

    def setUp(self) -> None:
        self.plantation = Plantation(self.valid_size)
        self.worker = 'Pesho'

    def test_initialization_with_negative_size_should_raise(self):
        with self.assertRaises(ValueError) as context:
            self.plantation.size = self.invalid_size

        self.assertIsNotNone(context.exception)
        self.assertEqual(str(context.exception), "Size must be positive number!")
        self.assertEqual(self.plantation.size, self.valid_size)

    def test_initialization_with_positive_size_should_work(self):
        plantation = Plantation(2)
        plantation.size += 1
        self.assertEqual(plantation.size, 3)

    def test_initialization_with_valid_works_correctly(self):
        self.assertEqual(self.plantation.size, self.valid_size)
        self.assertListEqual([], self.plantation.workers)
        self.assertDictEqual({}, self.plantation.plants)

    def test_len_works_correctly_after_add(self):
        self.plantation.plants['test_name'] = 'test_plant'

        self.assertEqual(len(self.plantation.plants), 1)

    def test_str_with_no_workers(self):
        plantation = Plantation(0)

        self.assertEqual(str(plantation), f"Plantation size: {plantation.size}\n")

    def test_hire_worker_raises_if_worker_already_added(self):
        with self.assertRaises(ValueError) as context:
            self.plantation.hire_worker(self.worker)
            self.plantation.hire_worker(self.worker)

        self.assertIsNotNone(context.exception)
        self.assertEqual(str(context.exception), "Worker already hired!")
        self.assertEqual(len(self.plantation.workers), 1)

    def test_planting_raises_on_invalid_worker_input(self):
        with self.assertRaises(ValueError) as context:
            self.plantation.planting(self.worker, 'rose')

        self.assertIsNotNone(context.exception)
        self.assertEqual(str(context.exception), f'Worker with name {self.worker} is not hired!')
        self.assertEqual(len(self.plantation.plants), 0)

    def test_planting_in_full_plantation_raises(self):
        with self.assertRaises(ValueError) as context:
            self.plantation.hire_worker(self.worker)
            for _ in range(self.valid_size):
                self.plantation.planting(self.worker, 'rose')
            self.plantation.planting(self.worker, 'rose')

        self.assertIsNotNone(context.exception)
        self.assertEqual(str(context.exception), "The plantation is full!")
        self.assertEqual(len(self.plantation), self.plantation.size)

    def test_worker_plants_successfully(self):
        self.plantation.hire_worker(self.worker)
        self.assertEqual(self.plantation.planting(self.worker, 'rose'), "Pesho planted it's first rose.")
        self.assertEqual(self.plantation.planting(self.worker, 'tulip'), "Pesho planted tulip.")

    def test_len_returns_correctly(self):
        self.plantation.hire_worker(self.worker)
        self.plantation.planting(self.worker, 'rose')
        self.plantation.planting(self.worker, 'rose')
        result = f'Plantation size: {self.plantation.size}'+'\n'+'Pesho'+'\n'+f'Pesho planted: rose, rose'

        self.assertEqual(result, str(self.plantation))

    def test_repr_returns_correctly(self):
        self.plantation.hire_worker(self.worker)
        self.plantation.hire_worker('Gosho')
        self.plantation.planting(self.worker, 'rose')
        self.plantation.planting(self.worker, 'rose')
        result = f'Size: {self.plantation.size}'+'\n'+'Workers: Pesho, Gosho'

        self.assertEqual(result, repr(self.plantation))


if __name__ == '__main__':
    unittest.main()
