from clock import Clock
import tracemalloc
import time


def main():
    """Main program function - equivalent to C# Main method"""
    seconds_in_a_day = 86400
    my_clock = Clock()

    for i in range(seconds_in_a_day):
        my_clock.tick()
        print(my_clock.get_time())


tracemalloc.start()
start = time.time()

main()

usage = tracemalloc.get_traced_memory()
print("Current Usage: ", usage[0])
print("Peak Usage: ", usage[1])

end = time.time()
print("Execution Time: ", end - start, "second")
tracemalloc.stop()
