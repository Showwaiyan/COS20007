from counter import Counter


class Clock:
    def __init__(self):
        # Fields
        self._hour = Counter("Hour")
        self._minute = Counter("Minute")
        self._second = Counter("Second")

    # Methods
    def tick(self):
        self._increment_second()

    def reset(self):
        self._second.reset()
        self._minute.reset()
        self._hour.reset()

    def _increment_second(self):
        self._second.increment()
        if self._second.ticks == 60:
            self._second.reset()
            self._increment_minute()

    def _increment_minute(self):
        self._minute.increment()
        if self._minute.ticks == 60:
            self._minute.reset()
            self._increment_hour()

    def _increment_hour(self):
        self._hour.increment()
        if self._hour.ticks == 13:
            self._hour.reset()
            self._hour.increment()

    def get_time(self):
        return f"{self._hour_str}:{self._minute_str}:{self._second_str}"

    # Properties
    @property
    def _hour_str(self):
        if self._hour.ticks == 0:
            self._hour.increment()
        return f"{self._hour.ticks:02d}"

    @property
    def _minute_str(self):
        return f"{self._minute.ticks:02d}"

    @property
    def _second_str(self):
        return f"{self._second.ticks:02d}"
