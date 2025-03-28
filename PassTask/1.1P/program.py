# Function to calculate the average of an array
def average(numbers):
    total = 0  # Initialize sum variable
    count = len(numbers)  # Get the total number of elements

    for num in numbers:
        total += num

    # Return the average
    return total / count
# Step 5: Marshal data
data_values = [2.5, -1.4, -7.2, -11.7, -13.5, -13.5, -14.9, -15.2, -14.0, -9.7, -2.6, 2.1]

# Invoke the function
result = average(data_values)

student_name = "Show Wai Yan"
student_id = "105293041"

# Print results
print("Average of data values:", result)
print("Student Name:", student_name)
print("Student ID:", student_id)

# Business logic for interpreting the result
if result >= 10:
    print("Multiple digits")
else:
    print("Single digits")

if result < 0:
    print("Average value negative")

last_digit_avg = abs(int(result)) % 10  # Get last digit of absolute average value
last_digit_id = int(student_id[-1])  # Get last digit of student ID


if last_digit_avg > last_digit_id:
    print("Larger than my last digit")
elif last_digit_avg < last_digit_id:
    print("Smaller than my last digit")
else:
    print("Equal to my last digit")
