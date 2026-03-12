# n = int(input("Enter the number of elements :"))

arr = list(map(int,input("Enter the array elements: ").split()))

def bubble_sort(n,arr):
    for turn in range(0,n-1):
        for j in range (n-turn-1):
            if arr[j]>arr[j+1]:
              arr[j],arr[j+1] = arr[j+1],arr[j]

    return arr

# print(bubble_sort(n,arr))

def selection_sort(arr):
    n = len(arr)
    for i in range (n-1):
        min_pos = i
        for j in range (i+1 ,n):
            if arr[min_pos]>arr[j]:
                min_pos = j
                arr[i],arr[min_pos]=arr[min_pos],arr[i]


    return arr

#print(selection_sort(arr))

def insetion_sort(arr):
    n = len(arr)
    for i in range(1, n):
        key = arr[i]
        j = i-1

        while j>=0 and arr[j]>key:
            arr[j+1] = arr[j]
            j-=1

        arr[j+1]=key
    
    return arr

print(insetion_sort(arr))

# merge sort

def merge_sort(arr):
    if len(arr) > 1:
        mid = len(arr) // 2
        L = arr[:mid]   
        R = arr[mid:]   

        
        merge_sort(L)
        merge_sort(R)

        i = j = k = 0

        
        while i < len(L) and j < len(R):
            if L[i] < R[j]:
                arr[k] = L[i]
                i += 1
            else:
                arr[k] = R[j]
                j += 1
            k += 1


        while i < len(L):
            arr[k] = L[i]
            i += 1
            k += 1

        
        while j < len(R):
            arr[k] = R[j]
            j += 1
            k += 1

#quick sort

def quick_sort(arr, low, high):
    if low < high:
        pivot = partition(arr, low, high)
        quick_sort(arr, low, pivot - 1)
        quick_sort(arr, pivot + 1, high)

def partition(arr, low, high):
    p = arr[high]   # pivot element
    i = low - 1     # index of smaller element

    for j in range(low, high):
        if arr[j] <= p:
            i += 1
            arr[i], arr[j] = arr[j], arr[i]

    arr[i + 1], arr[high] = arr[high], arr[i + 1]
    return i + 1


#binary tree traverslal

class Node:
    def __init__(self, data):
        self.data = data
        self.left = None
        self.right = None
        
def inorder(root):
    if root:
        inorder(root.left)
        print(root.data, end=' ')
        inorder(root.right)
        
def preorder(root):
    if root:
        print(root.data, end=' ')
        preorder(root.left)
        preorder(root.right)
        
def postorder(root):
    if root:
        postorder(root.left)
        postorder(root.right)
        print(root.data, end=' ')
        
def level_order(root):
    if root is None:
        return
    queue = []
    queue.append(root)
    while queue:
        current = queue.pop(0)
        print(current.data, end=' ')
        if current.left:
            queue.append(current.left)
        if current.right:
            queue.append(current.right)
            
# Example tree
root = Node(1)
root.left = Node(2)
root.right = Node(3)
root.left.left = Node(4)
root.left.right = Node(5)

print("Inorder Traversal:")
inorder(root)
print("\nPreorder Traversal:")
preorder(root)
print("\nPostorder Traversal:")
postorder(root)
print("\nLevel Order Traversal:")
level_order(root)


def quick_sort(arr):


if len(arr) <= 1:

return arr

pivot = arr[len(arr) // 2]

left = [x for x in arr if x < pivot]

middle = [x for x in arr if x == pivot]

right = [x for x in arr if x > pivot]

return (quick_sort(left) + middle + quick_sort(right))