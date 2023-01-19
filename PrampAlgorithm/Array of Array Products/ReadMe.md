# Array of Array Products

## Array

Time Complexity: $O(n)$

Space Complexity: $O(n) -> O(1)$

## Idea

|nums |2		    |7		      |3		    |4           |
|-----|-------------|-------------|-------------|------------|    
|ans  |  3 * 7 * 4  |  2 * 3 * 4  |  2 * 7 * 4  |  2 * 7 * 3  |
|l	  |             |  2 *	      |	 2 * 7      |  2 * 7 * 3 |
|r	  |  3 * 7 * 4 	|&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;3 * 4|&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;* 4|            |


## Similar case in leetcode

[238. Product of Array Except Self](https://leetcode.com/problems/product-of-array-except-self/)