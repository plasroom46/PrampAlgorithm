# Decrypt Message

## Simulation

n : word length

26: the range of lowercase latin letters(a ~ z)

m : To find the previous letter, count the number of times



enc[i] = dec[i] + secondStep[i-1] + 26m

dec[i] = enc[i] - secondStep[i-1] - 26m

Time Complexity: $O(n*m)$

Space Complexity: $O(n)$

## Similar case in leetcode
