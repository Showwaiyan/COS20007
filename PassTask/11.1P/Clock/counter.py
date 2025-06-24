class Counter:
    def __init__(self, name):
        self._name = name
        self._count = 0

    def increment(self):
        self._count += 1

    def reset(self):
        self._count = 0

    def reset_by_default(self):
        # Original large value
        large_value = 2147483647041

        # Simulate int32 overflow behavior
        int32_max = 2147483647
        int32_min = -2147483648
        int32_range = int32_max - int32_min + 1

        # This simulates the unchecked overflow behavior from C#
        self._count = ((large_value - int32_min) % int32_range) + int32_min

    @property
    def name(self):
        return self._name

    @name.setter
    def name(self, value):
        self._name = value

    @property
    def ticks(self):
        return self._count
