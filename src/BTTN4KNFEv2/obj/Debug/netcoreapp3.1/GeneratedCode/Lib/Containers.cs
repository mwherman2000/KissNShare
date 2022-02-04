#pragma warning disable 162,168,649,660,661,1522
using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using Trinity.Core.Lib;
using Trinity.TSL;
using Trinity.TSL.Lib;

namespace BTTN4KNFE
{
    public unsafe class intArray_150 : IEnumerable<int>
    {
        
        private static readonly int SizeDim0 = 150;
        
        /// <summary>
        /// Gets the rank (number of dimensions) of the Array.
        /// </summary>
        public static readonly int Rank = 1;
        internal byte* m_ptr;
        internal long m_cellId;
        internal intArray_150(byte* _CellPtr)
        {
            this.m_ptr = _CellPtr;
        }
        /// <summary>
        /// Gets the total number of elements
        /// </summary>
        public int Length
        {
            get
            {
                return
                    
                    SizeDim0
                    ;
            }
        }
        /// <summary>
        /// Returns a byte array that contains the value of this instance.
        /// </summary>
        /// <returns>a byte array.</returns>
        public unsafe byte[] ToByteArray()
        {
            byte[] ret = new byte[Length * 4];
            fixed (byte* ptr = ret)
            {
                Memory.Copy(m_ptr, ptr, Length * 4);
            }
            return ret;
        }
        
        /// <summary>
        /// Gets or sets the element at the specified index
        /// </summary>
        /// <returns>Corresponding element at the specified index</returns>
        public unsafe int this[
            
            int indexDim0
            ]
        {
            get
            {
                byte* offset = m_ptr + 
                    
                    indexDim0 * 1
                    ;
                
                {
                    return *(int*)offset;
                }
                
            }
            set
            {
                byte* offset = m_ptr + 
                    
                    indexDim0 * 1
                    ;
                
                {
                    *(int*)offset = value;
                }
                
            }
        }
        #region Foreach
        /// <summary>
        /// Performs the specified action on each element
        /// </summary>
        /// <param name="action">A lambda expression which has one parameter indicates element in array</param>
        public unsafe void ForEach(Action<int> action)
        {
            byte* targetPtr = m_ptr;
            byte* endPtr = m_ptr + Length * 4;
            while (targetPtr < endPtr)
            {
                
                {
                    action(*(int*)targetPtr);
                    targetPtr += 4;
                }
                
            }
        }
        internal unsafe struct _iterator
        {
            byte* targetPtr;
            byte* endPtr;
            intArray_150 target;
            internal _iterator(intArray_150 target)
            {
                targetPtr   = target.m_ptr;
                endPtr      = target.m_ptr + target.Length * 4;
                this.target = target;
            }
            internal bool good()
            {
                return (targetPtr < endPtr);
            }
            internal int current()
            {
                
                {
                    return *(int*)targetPtr;
                }
                
            }
            internal void move_next()
            {
                targetPtr += 4;
            }
        }
        public IEnumerator<int> GetEnumerator()
        {
            _iterator _it = new _iterator(this);
            while (_it.good())
            {
                yield return _it.current();
                _it.move_next();
            }
        }
        unsafe IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion
        /// <summary>
        /// Sets a range of elements in the Array to zero, to false, or to null, depending on the element type.
        /// </summary>
        /// <param name="index">The starting index of the range of elements to clear.</param>
        /// <param name="length">The number of elements to clear.</param>
        public unsafe void Clear(int index, int length)
        {
            if (index < 0 || length < 0 ||index >= Length || index+length > Length) throw new IndexOutOfRangeException();
            Memory.memset(m_ptr + index* 4, 0, (ulong)(length * 4));
        }
        public unsafe static implicit operator int[    ]
            (intArray_150 accessor)
        {
            int[    ] ret 
                = new int[  150  ];
            
            fixed (int* p = ret)
            {
                Memory.Copy(accessor.m_ptr, p, 600);
            }
            
            return ret;
        }
        
        public unsafe static implicit operator intArray_150(int[] field)
        {
            byte* targetPtr = null;
            targetPtr += 600;

            byte* tmpcellptr = BufferAllocator.AllocBuffer((int)targetPtr);
            Memory.memset(tmpcellptr, 0, (ulong)targetPtr);
            targetPtr = tmpcellptr;
                        if(field!= null){
                if(field.Rank != 1) throw new IndexOutOfRangeException("The assigned array'storage Rank mismatch.");
                if(field.GetLength(0) != 150) throw new IndexOutOfRangeException("The assigned array'storage dimension mismatch.");
               fixed(int* storedPtr_1 = field)
                   Memory.memcpy(targetPtr, storedPtr_1, (ulong)(600));
            } else {
                Memory.memset(targetPtr, 0, (ulong)(600));
            }
            targetPtr += 600;
intArray_150 ret;
            
            ret = new intArray_150(tmpcellptr);
            
            return ret;
        }
        
        public static bool operator == (intArray_150 a, intArray_150 b)
        {
            if (ReferenceEquals(a, b))
              return true;
            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
              return false;
            if (a.m_ptr == b.m_ptr) return true;
            return Memory.Compare(a.m_ptr, b.m_ptr, a.Length * 4);
        }
        public static bool operator != (intArray_150 a,intArray_150 b)
        {
            return !(a == b);
        }
    }
}

namespace BTTN4KNFE
{
    
    public unsafe class StringAccessorListAccessor : IEnumerable<StringAccessor>
    {
        internal byte* m_ptr;
        internal long m_cellId;
        internal ResizeFunctionDelegate ResizeFunction;
        internal StringAccessorListAccessor(byte* _CellPtr, ResizeFunctionDelegate func)
        {
            m_ptr = _CellPtr;
            ResizeFunction = func;
            m_ptr += 4;
                    elementAccessor = new StringAccessor(null,
                (ptr,ptr_offset,delta)=>
                {
                    int substructure_offset = (int)(ptr - this.m_ptr);
                    this.m_ptr = this.ResizeFunction(this.m_ptr-sizeof(int), ptr_offset + substructure_offset +sizeof(int), delta);
                    *(int*)this.m_ptr += delta;
                    this.m_ptr += sizeof(int);
                    return this.m_ptr + substructure_offset;
                });
        }
        internal int length
        {
            get
            {
                return *(int*)(m_ptr - 4);
            }
        }
        StringAccessor elementAccessor;
        
        /// <summary>
        /// Gets the number of elements actually contained in the List. 
        /// </summary>";
        public unsafe int Count
        {
            get
            {
                
                byte* targetPtr = m_ptr;
                byte* endPtr = m_ptr + length;
                int ret = 0;
                while (targetPtr < endPtr)
                {
                    targetPtr += *(int*)targetPtr + sizeof(int);
                    ++ret;
                }
                return ret;
                
            }
        }
        /// <summary>
        /// Gets or sets the element at the specified index. 
        /// </summary>
        /// <param name="index">Given index</param>
        /// <returns>Corresponding element at the specified index</returns>";
        public unsafe StringAccessor this[int index]
        {
            get
            {
                
                {
                    
                    {
                        byte* targetPtr = m_ptr;
                        while (index-- > 0)
                        {
                            targetPtr += *(int*)targetPtr + sizeof(int);
                        }
                        
                        elementAccessor.m_ptr = targetPtr + 4;
                        
                    }
                    
                    elementAccessor.m_cellId = this.m_cellId;
                    return elementAccessor;
                }
                
            }
            set
            {
                
                {
                    if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                    elementAccessor.m_cellId = this.m_cellId;
                    byte* targetPtr = m_ptr;
                    
                    while (index-- > 0)
                    {
                        targetPtr += *(int*)targetPtr + sizeof(int);
                    }
                    
                int length = *(int*)(value.m_ptr - 4);
                int oldlength = *(int*)targetPtr;
                if (value.m_cellId != elementAccessor.m_cellId)
                {
                    //if not in the same Cell
                    elementAccessor.m_ptr = elementAccessor.ResizeFunction(targetPtr, 0, length - oldlength);
                    Memory.Copy(value.m_ptr - 4, elementAccessor.m_ptr, length + 4);
                }
                else
                {
                    byte[] tmpcell = new byte[length + 4];
                    fixed (byte* tmpcellptr = tmpcell)
                    {                        
                        Memory.Copy(value.m_ptr - 4, tmpcellptr, length + 4);
                        elementAccessor.m_ptr = elementAccessor.ResizeFunction(targetPtr, 0, length - oldlength);
                        Memory.Copy(tmpcellptr, elementAccessor.m_ptr, length + 4);
                    }
                }

                }
                
            }
        }
        /// <summary>
        /// Copies the elements to a new byte array
        /// </summary>
        /// <returns>Elements compactly arranged in a byte array.</returns>
        public unsafe byte[] ToByteArray()
        {
            byte[] ret = new byte[length];
            fixed (byte* retptr = ret)
            {
                Memory.Copy(m_ptr, retptr, length);
                return ret;
            }
        }
        /// <summary>
        /// Performs the specified action on each elements
        /// </summary>
        /// <param name="action">A lambda expression which has one parameter indicates element in List</param>
        public unsafe void ForEach(Action<StringAccessor> action)
        {
            byte* targetPtr = m_ptr;
            byte* endPtr = m_ptr + length;
            
            elementAccessor.m_cellId = this.m_cellId;
            
            while (targetPtr < endPtr)
            {
                
                {
                    elementAccessor.m_ptr = targetPtr + 4;
                    action(elementAccessor);
                    targetPtr += *(int*)targetPtr + sizeof(int);
                }
                
            }
        }
        /// <summary>
        /// Performs the specified action on each elements
        /// </summary>
        /// <param name="action">A lambda expression which has two parameters. First indicates element in the List and second the index of this element.</param>
        public unsafe void ForEach(Action<StringAccessor, int> action)
        {
            byte* targetPtr = m_ptr;
            byte* endPtr = m_ptr + length;
            for (int index = 0; targetPtr < endPtr; ++index)
            {
                
                {
                    elementAccessor.m_ptr = targetPtr + 4;
                    action(elementAccessor, index);
                    targetPtr += *(int*)targetPtr + sizeof(int);
                }
                
            }
        }
        internal unsafe struct _iterator
        {
            byte* targetPtr;
            byte* endPtr;
            StringAccessorListAccessor target;
            internal _iterator(StringAccessorListAccessor target)
            {
                targetPtr = target.m_ptr;
                endPtr = targetPtr + target.length;
                this.target = target;
            }
            internal bool good()
            {
                return (targetPtr < endPtr);
            }
            internal StringAccessor current()
            {
                
                {
                    target.elementAccessor.m_ptr = targetPtr + 4;
                    return target.elementAccessor;
                }
                
            }
            internal void move_next()
            {
                 
                {
                    targetPtr += *(int*)targetPtr + sizeof(int);
                }
                
            }
        }
        public IEnumerator<StringAccessor> GetEnumerator()
        {
            _iterator _it = new _iterator(this);
            while (_it.good())
            {
                yield return _it.current();
                _it.move_next();
            }
        }
        unsafe IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        /// <summary>
        /// Adds an item to the end of the List
        /// </summary>
        /// <param name="element">The object to be added to the end of the List.</param>
        public unsafe void Add(string element)
        {
            byte* targetPtr = null;
            {
                
        if(element!= null)
        {
            int strlen_0 = element.Length * 2;
            targetPtr += strlen_0+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
            int size = (int)targetPtr;
            this.m_ptr = this.ResizeFunction(this.m_ptr - sizeof(int), *(int*)(this.m_ptr-sizeof(int))+sizeof(int), size);
            targetPtr = this.m_ptr + (*(int*)this.m_ptr)+sizeof(int);
            *(int*)this.m_ptr += size;
            this.m_ptr += sizeof(int);
            
        if(element!= null)
        {
            int strlen_0 = element.Length * 2;
            *(int*)targetPtr = strlen_0;
            targetPtr += sizeof(int);
            fixed(char* pstr_0 = element)
            {
                Memory.Copy(pstr_0, targetPtr, strlen_0);
                targetPtr += strlen_0;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        }
        /// <summary>
        /// Inserts an element into the List at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index at which item should be inserted.</param>
        /// <param name="element">The object to insert.</param>
        public unsafe void Insert(int index, string element)
        {
            if (index < 0 || index > Count) throw new IndexOutOfRangeException();
            byte* targetPtr = null;
            {
                
        if(element!= null)
        {
            int strlen_0 = element.Length * 2;
            targetPtr += strlen_0+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
            int size = (int)targetPtr;
            targetPtr = m_ptr;
            
            for (int i = 0; i < index; i++)
            {
                targetPtr += *(int*)targetPtr + sizeof(int);
            }
            
            int offset = (int)(targetPtr - m_ptr);
            this.m_ptr = this.ResizeFunction(this.m_ptr - sizeof(int), offset + sizeof(int), size);
            *(int*)this.m_ptr += size;
            this.m_ptr += sizeof(int);
            targetPtr = this.m_ptr + offset;
            
        if(element!= null)
        {
            int strlen_0 = element.Length * 2;
            *(int*)targetPtr = strlen_0;
            targetPtr += sizeof(int);
            fixed(char* pstr_0 = element)
            {
                Memory.Copy(pstr_0, targetPtr, strlen_0);
                targetPtr += strlen_0;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        }
        /// <summary>
        /// Inserts an element into a sorted list.
        /// </summary>
        /// <param name="element">The object to insert.</param>
        /// <param name="comparison"></param>
        public unsafe void Insert(string element, Comparison<StringAccessor> comparison)
        {
            byte* targetPtr = null;
            {
                
        if(element!= null)
        {
            int strlen_0 = element.Length * 2;
            targetPtr += strlen_0+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
            int size = (int)targetPtr;
            targetPtr = m_ptr;
            byte* endPtr = m_ptr + length;
            while (targetPtr<endPtr)
            {
                
            }
            int offset = (int)(targetPtr - m_ptr);
            this.m_ptr = this.ResizeFunction(this.m_ptr - sizeof(int), offset + sizeof(int), size);
            *(int*)this.m_ptr += size;
            this.m_ptr += sizeof(int);
            targetPtr = this.m_ptr + offset;
            
        if(element!= null)
        {
            int strlen_0 = element.Length * 2;
            *(int*)targetPtr = strlen_0;
            targetPtr += sizeof(int);
            fixed(char* pstr_0 = element)
            {
                Memory.Copy(pstr_0, targetPtr, strlen_0);
                targetPtr += strlen_0;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        }
        /// <summary>
        /// Removes the element at the specified index of the List.
        /// </summary>
        /// <param name="index">The zero-based index of the element to remove.</param>
        public unsafe void RemoveAt(int index)
        {
            if (index < 0 || index >= Count) throw new IndexOutOfRangeException();
            byte* targetPtr = m_ptr;
            for (int i = 0; i < index; i++)
            {
                targetPtr += *(int*)targetPtr + sizeof(int);
            }
            int offset = (int)(targetPtr - m_ptr);
            byte* oldtargetPtr = targetPtr;
            targetPtr += *(int*)targetPtr + sizeof(int);
            int size = (int)(oldtargetPtr - targetPtr);
            this.m_ptr = this.ResizeFunction(this.m_ptr - sizeof(int), offset + sizeof(int), size);
            *(int*)this.m_ptr += size;
            this.m_ptr += sizeof(int);
        }
        /// <summary>
        /// Adds the elements of the specified collection to the end of the List
        /// </summary>
        /// <param name="collection">The collection whose elements should be added to the end of the List. The collection itself cannot be null.</param>
        public unsafe void AddRange(List<string> collection)
        {
            if (collection == null) throw new ArgumentNullException("collection is null.");
            StringAccessorListAccessor tcollection = collection;
            int delta = tcollection.length;
            m_ptr = ResizeFunction(m_ptr - 4, *(int*)(m_ptr - 4) + 4, delta);
            Memory.Copy(tcollection.m_ptr, m_ptr + *(int*)m_ptr + 4, delta);
            *(int*)m_ptr += delta;
            this.m_ptr += 4;
        }
        /// <summary>
        /// Adds the elements of the specified collection to the end of the List
        /// </summary>
        /// <param name="collection">The collection whose elements should be added to the end of the List. The collection itself cannot be null.</param>
        public unsafe void AddRange(StringAccessorListAccessor collection)
        {
            if (collection == null) throw new ArgumentNullException("collection is null.");
            int delta = collection.length;
            if (collection.m_cellId != m_cellId)
            {
                m_ptr = ResizeFunction(m_ptr - 4, *(int*)(m_ptr - 4) + 4, delta);
                Memory.Copy(collection.m_ptr, m_ptr + *(int*)m_ptr + 4, delta);
                *(int*)m_ptr += delta;
            }
            else
            {
                byte[] tmpcell = new byte[delta];
                fixed (byte* tmpcellptr = tmpcell)
                {
                    Memory.Copy(collection.m_ptr, tmpcellptr, delta);
                    m_ptr = ResizeFunction(m_ptr - 4, *(int*)(m_ptr - 4) + 4, delta);
                    Memory.Copy(tmpcellptr, m_ptr + *(int*)m_ptr + 4, delta);
                    *(int*)m_ptr += delta;
                }
            }
            this.m_ptr += 4;
        }
        /// <summary>
        /// Removes all elements from the List
        /// </summary>
        public unsafe void Clear()
        {
            int delta = length;
            Memory.memset(m_ptr, 0, (ulong)delta);
            m_ptr = ResizeFunction(m_ptr - 4, 4, -delta);
            *(int*)m_ptr = 0;
            this.m_ptr += 4;
        }
        /// <summary>
        /// Determines whether an element is in the List
        /// </summary>
        /// <param name="item">The object to locate in the List.The value can be null for non-atom types</param>
        /// <returns>true if item is found in the List; otherwise, false.</returns>
        public unsafe bool Contains(StringAccessor item)
        {
            bool ret = false;
            ForEach(x =>
            {
                if (item == x) ret = true;
            });
            return ret;
        }
        /// <summary>
        /// Determines whether the List contains elements that match the conditions defined by the specified predicate.
        /// </summary>
        /// <param name="match">The Predicate delegate that defines the conditions of the elements to search for.</param>
        /// <returns>true if the List contains one or more elements that match the conditions defined by the specified predicate; otherwise, false.</returns>
        public unsafe bool Exists(Predicate<StringAccessor> match)
        {
            bool ret = false;
            ForEach(x =>
            {
                if (match(x)) ret = true;
            });
            return ret;
        }
        
        /// <summary>
        /// Copies the entire List to a compatible one-dimensional array, starting at the beginning of the ptr1 array.
        /// </summary>
        /// <param name="array">The one-dimensional Array that is the destination of the elements copied from List. The Array must have zero-based indexing.</param>
        public unsafe void CopyTo(string[] array)
        {
            if (array == null) throw new ArgumentNullException("array is null.");
            if (array.Length < Count) throw new ArgumentException("The number of elements in the source List is greater than the number of elements that the destination array can contain.");
            ForEach((x, i) => array[i] = x);
        }
        /// <summary>
        /// Copies the entire List to a compatible one-dimensional array, starting at the specified index of the ptr1 array.
        /// </summary>
        /// <param name="array">The one-dimensional Array that is the destination of the elements copied from List. The Array must have zero-based indexing.</param>
        /// <param name="arrayIndex">The zero-based index in array at which copying begins.</param>
        public unsafe void CopyTo(string[] array, int arrayIndex)
        {
            if (array == null) throw new ArgumentNullException("array is null.");
            if (arrayIndex < 0) throw new ArgumentOutOfRangeException("arrayIndex is less than 0.");
            if (array.Length - arrayIndex < Count) throw new ArgumentException("The number of elements in the source List is greater than the available space from arrayIndex to the end of the destination array.");
            ForEach((x, i) => array[i + arrayIndex] = x);
        }
        /// <summary>
        /// Copies a range of elements from the List to a compatible one-dimensional array, starting at the specified index of the ptr1 array.
        /// </summary>
        /// <param name="index">The zero-based index in the source List at which copying begins.</param>
        /// <param name="array">The one-dimensional Array that is the destination of the elements copied from List. The Array must have zero-based indexing.</param>
        /// <param name="arrayIndex">The zero-based index in array at which copying begins.</param>;
        /// <param name="count">The number of elements to copy.</param>
        public unsafe void CopyTo(int index, string[] array, int arrayIndex, int count)
        {
            if (array == null) throw new ArgumentNullException("array is null.");
            if (arrayIndex < 0 || index < 0 || count < 0) throw new ArgumentOutOfRangeException("arrayIndex is less than 0 or index is less than 0 or count is less than 0.");
            if (array.Length - arrayIndex < count) throw new ArgumentException("The number of elements from index to the end of the source List is greater than the available space from arrayIndex to the end of the destination array. ");
            if (index + count > Count) throw new ArgumentException("Source list does not have enough elements to copy.");
            int j = 0;
            for (int i = index; i < index + count; i++)
            {
                array[j + arrayIndex] = this[i];
                ++j;
            }
        }
          
        /// <summary>
        /// Inserts the elements of a collection into the List at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index at which the new elements should be inserted.</param>
        /// <param name="collection">The collection whose elements should be inserted into the List. The collection itself cannot be null, but it can contain elements that are null, if type T is a reference type.</param>
        public unsafe void InsertRange(int index, List<string> collection)
        {
            if (collection == null) throw new ArgumentNullException("collection is null.");
            if (index < 0) throw new ArgumentOutOfRangeException("index is less than 0.");
            if (index > Count) throw new ArgumentOutOfRangeException("index is greater than Count.");
            StringAccessorListAccessor tmpAccessor = collection;
            byte* targetPtr = m_ptr;
            for (int i = 0; i < index; i++)
            {
                targetPtr += *(int*)targetPtr + sizeof(int);
            }
            int offset = (int)(targetPtr - m_ptr);
            m_ptr = ResizeFunction(m_ptr - 4, offset + 4, tmpAccessor.length);
            Memory.Copy(tmpAccessor.m_ptr, m_ptr + offset + 4, tmpAccessor.length);
            *(int*)m_ptr += tmpAccessor.length;
            this.m_ptr += 4;
        }
        /// <summary>
        /// Removes a range of elements from the List.
        /// </summary>
        /// <param name="index">The zero-based starting index of the range of elements to remove.</param>
        /// <param name="count">The number of elements to remove.</param>
        public unsafe void RemoveRange(int index, int count)
        {
            if (index < 0) throw new ArgumentOutOfRangeException("index is less than 0.");
            if (index > Count) throw new ArgumentOutOfRangeException("index is greater than Count.");
            if (index + count > Count) throw new ArgumentException("index and count do not denote a valid range of elements in the List.");
            byte* targetPtr = m_ptr;
            for (int i = 0; i < index; i++)
            {
                targetPtr += *(int*)targetPtr + sizeof(int);
            }
            int offset = (int)(targetPtr - m_ptr);
            byte* oldtargetPtr = targetPtr;
            for (int i = 0; i < count; i++)
            {
                targetPtr += *(int*)targetPtr + sizeof(int);
            }
            int size = (int)(oldtargetPtr - targetPtr);
            m_ptr = ResizeFunction(m_ptr - 4, offset + 4, size);
            *(int*)m_ptr += size;
            this.m_ptr += 4;
        }
        public unsafe static implicit operator List<string> (StringAccessorListAccessor accessor)
        {
            if((object)accessor == null) return null;
            List<string> list = new List<string>();
            accessor.ForEach(element => list.Add(element));
            return list;
        }
        
        public unsafe static implicit operator StringAccessorListAccessor(List<string> field)
        {
            byte* targetPtr = null;
            
{

    targetPtr += sizeof(int);
    if(field!= null)
    {
        for(int iterator_1 = 0;iterator_1<field.Count;++iterator_1)
        {

        if(field[iterator_1]!= null)
        {
            int strlen_2 = field[iterator_1].Length * 2;
            targetPtr += strlen_2+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        }
    }

}

            byte* tmpcellptr = BufferAllocator.AllocBuffer((int)targetPtr);
            Memory.memset(tmpcellptr, 0, (ulong)targetPtr);
            targetPtr = tmpcellptr;
            
{
byte *storedPtr_1 = targetPtr;

    targetPtr += sizeof(int);
    if(field!= null)
    {
        for(int iterator_1 = 0;iterator_1<field.Count;++iterator_1)
        {

        if(field[iterator_1]!= null)
        {
            int strlen_2 = field[iterator_1].Length * 2;
            *(int*)targetPtr = strlen_2;
            targetPtr += sizeof(int);
            fixed(char* pstr_2 = field[iterator_1])
            {
                Memory.Copy(pstr_2, targetPtr, strlen_2);
                targetPtr += strlen_2;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        }
    }
*(int*)storedPtr_1 = (int)(targetPtr - storedPtr_1 - 4);

}
StringAccessorListAccessor ret;
            
            ret = new StringAccessorListAccessor(tmpcellptr, null);
            
            return ret;
        }
        
        public static bool operator ==(StringAccessorListAccessor a, StringAccessorListAccessor b)
        {
            if (ReferenceEquals(a, b))
                return true;
            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;
            if (a.m_ptr == b.m_ptr) return true;
            if (a.length != b.length) return false;
            return Memory.Compare(a.m_ptr, b.m_ptr, a.length);
        }
        public static bool operator !=(StringAccessorListAccessor a, StringAccessorListAccessor b)
        {
            return !(a == b);
        }
    }
}

namespace BTTN4KNFE
{
    
    public unsafe class BTTKeyValuePair_AccessorListAccessor : IEnumerable<BTTKeyValuePair_Accessor>
    {
        internal byte* m_ptr;
        internal long m_cellId;
        internal ResizeFunctionDelegate ResizeFunction;
        internal BTTKeyValuePair_AccessorListAccessor(byte* _CellPtr, ResizeFunctionDelegate func)
        {
            m_ptr = _CellPtr;
            ResizeFunction = func;
            m_ptr += 4;
                    elementAccessor = new BTTKeyValuePair_Accessor(null,
                (ptr,ptr_offset,delta)=>
                {
                    int substructure_offset = (int)(ptr - this.m_ptr);
                    this.m_ptr = this.ResizeFunction(this.m_ptr-sizeof(int), ptr_offset + substructure_offset +sizeof(int), delta);
                    *(int*)this.m_ptr += delta;
                    this.m_ptr += sizeof(int);
                    return this.m_ptr + substructure_offset;
                });
        }
        internal int length
        {
            get
            {
                return *(int*)(m_ptr - 4);
            }
        }
        BTTKeyValuePair_Accessor elementAccessor;
        
        /// <summary>
        /// Gets the number of elements actually contained in the List. 
        /// </summary>";
        public unsafe int Count
        {
            get
            {
                
                byte* targetPtr = m_ptr;
                byte* endPtr = m_ptr + length;
                int ret = 0;
                while (targetPtr < endPtr)
                {
                    {targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}
                    ++ret;
                }
                return ret;
                
            }
        }
        /// <summary>
        /// Gets or sets the element at the specified index. 
        /// </summary>
        /// <param name="index">Given index</param>
        /// <returns>Corresponding element at the specified index</returns>";
        public unsafe BTTKeyValuePair_Accessor this[int index]
        {
            get
            {
                
                {
                    
                    {
                        byte* targetPtr = m_ptr;
                        while (index-- > 0)
                        {
                            {targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}
                        }
                        
                        elementAccessor.m_ptr = targetPtr;
                        
                    }
                    
                    elementAccessor.m_cellId = this.m_cellId;
                    return elementAccessor;
                }
                
            }
            set
            {
                
                {
                    if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                    elementAccessor.m_cellId = this.m_cellId;
                    byte* targetPtr = m_ptr;
                    
                    while (index-- > 0)
                    {
                        {targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}
                    }
                    
                int offset = (int)(targetPtr - m_ptr);
                byte* oldtargetPtr = targetPtr;
                int oldlength = (int)(targetPtr - oldtargetPtr);
                targetPtr = value.m_ptr;
                int newlength = (int)(targetPtr - value.m_ptr);
                if (newlength != oldlength)
                {
                    if (value.m_cellId != this.m_cellId)
                    {
                        this.m_ptr = this.ResizeFunction(this.m_ptr, offset, newlength - oldlength);
                        Memory.Copy(value.m_ptr, this.m_ptr + offset, newlength);
                    }
                    else
                    {
                        byte[] tmpcell = new byte[newlength];
                        fixed(byte* tmpcellptr = tmpcell)
                        {
                            Memory.Copy(value.m_ptr, tmpcellptr, newlength);
                            this.m_ptr = this.ResizeFunction(this.m_ptr, offset, newlength - oldlength);
                            Memory.Copy(tmpcellptr, this.m_ptr + offset, newlength);
                        }
                    }
                }
                else
                {
                    Memory.Copy(value.m_ptr, oldtargetPtr, oldlength);
                }
                }
                
            }
        }
        /// <summary>
        /// Copies the elements to a new byte array
        /// </summary>
        /// <returns>Elements compactly arranged in a byte array.</returns>
        public unsafe byte[] ToByteArray()
        {
            byte[] ret = new byte[length];
            fixed (byte* retptr = ret)
            {
                Memory.Copy(m_ptr, retptr, length);
                return ret;
            }
        }
        /// <summary>
        /// Performs the specified action on each elements
        /// </summary>
        /// <param name="action">A lambda expression which has one parameter indicates element in List</param>
        public unsafe void ForEach(Action<BTTKeyValuePair_Accessor> action)
        {
            byte* targetPtr = m_ptr;
            byte* endPtr = m_ptr + length;
            
            elementAccessor.m_cellId = this.m_cellId;
            
            while (targetPtr < endPtr)
            {
                
                {
                    elementAccessor.m_ptr = targetPtr;
                    action(elementAccessor);
                    {targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}
                }
                
            }
        }
        /// <summary>
        /// Performs the specified action on each elements
        /// </summary>
        /// <param name="action">A lambda expression which has two parameters. First indicates element in the List and second the index of this element.</param>
        public unsafe void ForEach(Action<BTTKeyValuePair_Accessor, int> action)
        {
            byte* targetPtr = m_ptr;
            byte* endPtr = m_ptr + length;
            for (int index = 0; targetPtr < endPtr; ++index)
            {
                
                {
                    elementAccessor.m_ptr = targetPtr;
                    action(elementAccessor, index);
                    {targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}
                }
                
            }
        }
        internal unsafe struct _iterator
        {
            byte* targetPtr;
            byte* endPtr;
            BTTKeyValuePair_AccessorListAccessor target;
            internal _iterator(BTTKeyValuePair_AccessorListAccessor target)
            {
                targetPtr = target.m_ptr;
                endPtr = targetPtr + target.length;
                this.target = target;
            }
            internal bool good()
            {
                return (targetPtr < endPtr);
            }
            internal BTTKeyValuePair_Accessor current()
            {
                
                {
                    target.elementAccessor.m_ptr = targetPtr;
                    return target.elementAccessor;
                }
                
            }
            internal void move_next()
            {
                 
                {
                    {targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}
                }
                
            }
        }
        public IEnumerator<BTTKeyValuePair_Accessor> GetEnumerator()
        {
            _iterator _it = new _iterator(this);
            while (_it.good())
            {
                yield return _it.current();
                _it.move_next();
            }
        }
        unsafe IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        /// <summary>
        /// Adds an item to the end of the List
        /// </summary>
        /// <param name="element">The object to be added to the end of the List.</param>
        public unsafe void Add(BTTKeyValuePair element)
        {
            byte* targetPtr = null;
            {
                
            {

        if(element.key!= null)
        {
            int strlen_1 = element.key.Length * 2;
            targetPtr += strlen_1+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(element.value!= null)
        {
            int strlen_1 = element.value.Length * 2;
            targetPtr += strlen_1+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
            }
            int size = (int)targetPtr;
            this.m_ptr = this.ResizeFunction(this.m_ptr - sizeof(int), *(int*)(this.m_ptr-sizeof(int))+sizeof(int), size);
            targetPtr = this.m_ptr + (*(int*)this.m_ptr)+sizeof(int);
            *(int*)this.m_ptr += size;
            this.m_ptr += sizeof(int);
            
            {

        if(element.key!= null)
        {
            int strlen_1 = element.key.Length * 2;
            *(int*)targetPtr = strlen_1;
            targetPtr += sizeof(int);
            fixed(char* pstr_1 = element.key)
            {
                Memory.Copy(pstr_1, targetPtr, strlen_1);
                targetPtr += strlen_1;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(element.value!= null)
        {
            int strlen_1 = element.value.Length * 2;
            *(int*)targetPtr = strlen_1;
            targetPtr += sizeof(int);
            fixed(char* pstr_1 = element.value)
            {
                Memory.Copy(pstr_1, targetPtr, strlen_1);
                targetPtr += strlen_1;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            }
        }
        /// <summary>
        /// Inserts an element into the List at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index at which item should be inserted.</param>
        /// <param name="element">The object to insert.</param>
        public unsafe void Insert(int index, BTTKeyValuePair element)
        {
            if (index < 0 || index > Count) throw new IndexOutOfRangeException();
            byte* targetPtr = null;
            {
                
            {

        if(element.key!= null)
        {
            int strlen_1 = element.key.Length * 2;
            targetPtr += strlen_1+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(element.value!= null)
        {
            int strlen_1 = element.value.Length * 2;
            targetPtr += strlen_1+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
            }
            int size = (int)targetPtr;
            targetPtr = m_ptr;
            
            for (int i = 0; i < index; i++)
            {
                {targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}
            }
            
            int offset = (int)(targetPtr - m_ptr);
            this.m_ptr = this.ResizeFunction(this.m_ptr - sizeof(int), offset + sizeof(int), size);
            *(int*)this.m_ptr += size;
            this.m_ptr += sizeof(int);
            targetPtr = this.m_ptr + offset;
            
            {

        if(element.key!= null)
        {
            int strlen_1 = element.key.Length * 2;
            *(int*)targetPtr = strlen_1;
            targetPtr += sizeof(int);
            fixed(char* pstr_1 = element.key)
            {
                Memory.Copy(pstr_1, targetPtr, strlen_1);
                targetPtr += strlen_1;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(element.value!= null)
        {
            int strlen_1 = element.value.Length * 2;
            *(int*)targetPtr = strlen_1;
            targetPtr += sizeof(int);
            fixed(char* pstr_1 = element.value)
            {
                Memory.Copy(pstr_1, targetPtr, strlen_1);
                targetPtr += strlen_1;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            }
        }
        /// <summary>
        /// Inserts an element into a sorted list.
        /// </summary>
        /// <param name="element">The object to insert.</param>
        /// <param name="comparison"></param>
        public unsafe void Insert(BTTKeyValuePair element, Comparison<BTTKeyValuePair_Accessor> comparison)
        {
            byte* targetPtr = null;
            {
                
            {

        if(element.key!= null)
        {
            int strlen_1 = element.key.Length * 2;
            targetPtr += strlen_1+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(element.value!= null)
        {
            int strlen_1 = element.value.Length * 2;
            targetPtr += strlen_1+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
            }
            int size = (int)targetPtr;
            targetPtr = m_ptr;
            byte* endPtr = m_ptr + length;
            while (targetPtr<endPtr)
            {
                
                {
                    elementAccessor.m_ptr = targetPtr + 4;
                    if (comparison(elementAccessor, element)<=0)
                    {
                        {targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}
                    }
                    else
                    {
                        break;
                    }
                }
                
            }
            int offset = (int)(targetPtr - m_ptr);
            this.m_ptr = this.ResizeFunction(this.m_ptr - sizeof(int), offset + sizeof(int), size);
            *(int*)this.m_ptr += size;
            this.m_ptr += sizeof(int);
            targetPtr = this.m_ptr + offset;
            
            {

        if(element.key!= null)
        {
            int strlen_1 = element.key.Length * 2;
            *(int*)targetPtr = strlen_1;
            targetPtr += sizeof(int);
            fixed(char* pstr_1 = element.key)
            {
                Memory.Copy(pstr_1, targetPtr, strlen_1);
                targetPtr += strlen_1;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(element.value!= null)
        {
            int strlen_1 = element.value.Length * 2;
            *(int*)targetPtr = strlen_1;
            targetPtr += sizeof(int);
            fixed(char* pstr_1 = element.value)
            {
                Memory.Copy(pstr_1, targetPtr, strlen_1);
                targetPtr += strlen_1;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            }
        }
        /// <summary>
        /// Removes the element at the specified index of the List.
        /// </summary>
        /// <param name="index">The zero-based index of the element to remove.</param>
        public unsafe void RemoveAt(int index)
        {
            if (index < 0 || index >= Count) throw new IndexOutOfRangeException();
            byte* targetPtr = m_ptr;
            for (int i = 0; i < index; i++)
            {
                {targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}
            }
            int offset = (int)(targetPtr - m_ptr);
            byte* oldtargetPtr = targetPtr;
            {targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}
            int size = (int)(oldtargetPtr - targetPtr);
            this.m_ptr = this.ResizeFunction(this.m_ptr - sizeof(int), offset + sizeof(int), size);
            *(int*)this.m_ptr += size;
            this.m_ptr += sizeof(int);
        }
        /// <summary>
        /// Adds the elements of the specified collection to the end of the List
        /// </summary>
        /// <param name="collection">The collection whose elements should be added to the end of the List. The collection itself cannot be null.</param>
        public unsafe void AddRange(List<BTTKeyValuePair> collection)
        {
            if (collection == null) throw new ArgumentNullException("collection is null.");
            BTTKeyValuePair_AccessorListAccessor tcollection = collection;
            int delta = tcollection.length;
            m_ptr = ResizeFunction(m_ptr - 4, *(int*)(m_ptr - 4) + 4, delta);
            Memory.Copy(tcollection.m_ptr, m_ptr + *(int*)m_ptr + 4, delta);
            *(int*)m_ptr += delta;
            this.m_ptr += 4;
        }
        /// <summary>
        /// Adds the elements of the specified collection to the end of the List
        /// </summary>
        /// <param name="collection">The collection whose elements should be added to the end of the List. The collection itself cannot be null.</param>
        public unsafe void AddRange(BTTKeyValuePair_AccessorListAccessor collection)
        {
            if (collection == null) throw new ArgumentNullException("collection is null.");
            int delta = collection.length;
            if (collection.m_cellId != m_cellId)
            {
                m_ptr = ResizeFunction(m_ptr - 4, *(int*)(m_ptr - 4) + 4, delta);
                Memory.Copy(collection.m_ptr, m_ptr + *(int*)m_ptr + 4, delta);
                *(int*)m_ptr += delta;
            }
            else
            {
                byte[] tmpcell = new byte[delta];
                fixed (byte* tmpcellptr = tmpcell)
                {
                    Memory.Copy(collection.m_ptr, tmpcellptr, delta);
                    m_ptr = ResizeFunction(m_ptr - 4, *(int*)(m_ptr - 4) + 4, delta);
                    Memory.Copy(tmpcellptr, m_ptr + *(int*)m_ptr + 4, delta);
                    *(int*)m_ptr += delta;
                }
            }
            this.m_ptr += 4;
        }
        /// <summary>
        /// Removes all elements from the List
        /// </summary>
        public unsafe void Clear()
        {
            int delta = length;
            Memory.memset(m_ptr, 0, (ulong)delta);
            m_ptr = ResizeFunction(m_ptr - 4, 4, -delta);
            *(int*)m_ptr = 0;
            this.m_ptr += 4;
        }
        /// <summary>
        /// Determines whether an element is in the List
        /// </summary>
        /// <param name="item">The object to locate in the List.The value can be null for non-atom types</param>
        /// <returns>true if item is found in the List; otherwise, false.</returns>
        public unsafe bool Contains(BTTKeyValuePair_Accessor item)
        {
            bool ret = false;
            ForEach(x =>
            {
                if (item == x) ret = true;
            });
            return ret;
        }
        /// <summary>
        /// Determines whether the List contains elements that match the conditions defined by the specified predicate.
        /// </summary>
        /// <param name="match">The Predicate delegate that defines the conditions of the elements to search for.</param>
        /// <returns>true if the List contains one or more elements that match the conditions defined by the specified predicate; otherwise, false.</returns>
        public unsafe bool Exists(Predicate<BTTKeyValuePair_Accessor> match)
        {
            bool ret = false;
            ForEach(x =>
            {
                if (match(x)) ret = true;
            });
            return ret;
        }
        
        /// <summary>
        /// Copies the entire List to a compatible one-dimensional array, starting at the beginning of the ptr1 array.
        /// </summary>
        /// <param name="array">The one-dimensional Array that is the destination of the elements copied from List. The Array must have zero-based indexing.</param>
        public unsafe void CopyTo(BTTKeyValuePair[] array)
        {
            if (array == null) throw new ArgumentNullException("array is null.");
            if (array.Length < Count) throw new ArgumentException("The number of elements in the source List is greater than the number of elements that the destination array can contain.");
            ForEach((x, i) => array[i] = x);
        }
        /// <summary>
        /// Copies the entire List to a compatible one-dimensional array, starting at the specified index of the ptr1 array.
        /// </summary>
        /// <param name="array">The one-dimensional Array that is the destination of the elements copied from List. The Array must have zero-based indexing.</param>
        /// <param name="arrayIndex">The zero-based index in array at which copying begins.</param>
        public unsafe void CopyTo(BTTKeyValuePair[] array, int arrayIndex)
        {
            if (array == null) throw new ArgumentNullException("array is null.");
            if (arrayIndex < 0) throw new ArgumentOutOfRangeException("arrayIndex is less than 0.");
            if (array.Length - arrayIndex < Count) throw new ArgumentException("The number of elements in the source List is greater than the available space from arrayIndex to the end of the destination array.");
            ForEach((x, i) => array[i + arrayIndex] = x);
        }
        /// <summary>
        /// Copies a range of elements from the List to a compatible one-dimensional array, starting at the specified index of the ptr1 array.
        /// </summary>
        /// <param name="index">The zero-based index in the source List at which copying begins.</param>
        /// <param name="array">The one-dimensional Array that is the destination of the elements copied from List. The Array must have zero-based indexing.</param>
        /// <param name="arrayIndex">The zero-based index in array at which copying begins.</param>;
        /// <param name="count">The number of elements to copy.</param>
        public unsafe void CopyTo(int index, BTTKeyValuePair[] array, int arrayIndex, int count)
        {
            if (array == null) throw new ArgumentNullException("array is null.");
            if (arrayIndex < 0 || index < 0 || count < 0) throw new ArgumentOutOfRangeException("arrayIndex is less than 0 or index is less than 0 or count is less than 0.");
            if (array.Length - arrayIndex < count) throw new ArgumentException("The number of elements from index to the end of the source List is greater than the available space from arrayIndex to the end of the destination array. ");
            if (index + count > Count) throw new ArgumentException("Source list does not have enough elements to copy.");
            int j = 0;
            for (int i = index; i < index + count; i++)
            {
                array[j + arrayIndex] = this[i];
                ++j;
            }
        }
          
        /// <summary>
        /// Inserts the elements of a collection into the List at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index at which the new elements should be inserted.</param>
        /// <param name="collection">The collection whose elements should be inserted into the List. The collection itself cannot be null, but it can contain elements that are null, if type T is a reference type.</param>
        public unsafe void InsertRange(int index, List<BTTKeyValuePair> collection)
        {
            if (collection == null) throw new ArgumentNullException("collection is null.");
            if (index < 0) throw new ArgumentOutOfRangeException("index is less than 0.");
            if (index > Count) throw new ArgumentOutOfRangeException("index is greater than Count.");
            BTTKeyValuePair_AccessorListAccessor tmpAccessor = collection;
            byte* targetPtr = m_ptr;
            for (int i = 0; i < index; i++)
            {
                {targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}
            }
            int offset = (int)(targetPtr - m_ptr);
            m_ptr = ResizeFunction(m_ptr - 4, offset + 4, tmpAccessor.length);
            Memory.Copy(tmpAccessor.m_ptr, m_ptr + offset + 4, tmpAccessor.length);
            *(int*)m_ptr += tmpAccessor.length;
            this.m_ptr += 4;
        }
        /// <summary>
        /// Removes a range of elements from the List.
        /// </summary>
        /// <param name="index">The zero-based starting index of the range of elements to remove.</param>
        /// <param name="count">The number of elements to remove.</param>
        public unsafe void RemoveRange(int index, int count)
        {
            if (index < 0) throw new ArgumentOutOfRangeException("index is less than 0.");
            if (index > Count) throw new ArgumentOutOfRangeException("index is greater than Count.");
            if (index + count > Count) throw new ArgumentException("index and count do not denote a valid range of elements in the List.");
            byte* targetPtr = m_ptr;
            for (int i = 0; i < index; i++)
            {
                {targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}
            }
            int offset = (int)(targetPtr - m_ptr);
            byte* oldtargetPtr = targetPtr;
            for (int i = 0; i < count; i++)
            {
                {targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}
            }
            int size = (int)(oldtargetPtr - targetPtr);
            m_ptr = ResizeFunction(m_ptr - 4, offset + 4, size);
            *(int*)m_ptr += size;
            this.m_ptr += 4;
        }
        public unsafe static implicit operator List<BTTKeyValuePair> (BTTKeyValuePair_AccessorListAccessor accessor)
        {
            if((object)accessor == null) return null;
            List<BTTKeyValuePair> list = new List<BTTKeyValuePair>();
            accessor.ForEach(element => list.Add(element));
            return list;
        }
        
        public unsafe static implicit operator BTTKeyValuePair_AccessorListAccessor(List<BTTKeyValuePair> field)
        {
            byte* targetPtr = null;
            
{

    targetPtr += sizeof(int);
    if(field!= null)
    {
        for(int iterator_1 = 0;iterator_1<field.Count;++iterator_1)
        {

            {

        if(field[iterator_1].key!= null)
        {
            int strlen_3 = field[iterator_1].key.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(field[iterator_1].value!= null)
        {
            int strlen_3 = field[iterator_1].value.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
        }
    }

}

            byte* tmpcellptr = BufferAllocator.AllocBuffer((int)targetPtr);
            Memory.memset(tmpcellptr, 0, (ulong)targetPtr);
            targetPtr = tmpcellptr;
            
{
byte *storedPtr_1 = targetPtr;

    targetPtr += sizeof(int);
    if(field!= null)
    {
        for(int iterator_1 = 0;iterator_1<field.Count;++iterator_1)
        {

            {

        if(field[iterator_1].key!= null)
        {
            int strlen_3 = field[iterator_1].key.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = field[iterator_1].key)
            {
                Memory.Copy(pstr_3, targetPtr, strlen_3);
                targetPtr += strlen_3;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(field[iterator_1].value!= null)
        {
            int strlen_3 = field[iterator_1].value.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = field[iterator_1].value)
            {
                Memory.Copy(pstr_3, targetPtr, strlen_3);
                targetPtr += strlen_3;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            }
        }
    }
*(int*)storedPtr_1 = (int)(targetPtr - storedPtr_1 - 4);

}
BTTKeyValuePair_AccessorListAccessor ret;
            
            ret = new BTTKeyValuePair_AccessorListAccessor(tmpcellptr, null);
            
            return ret;
        }
        
        public static bool operator ==(BTTKeyValuePair_AccessorListAccessor a, BTTKeyValuePair_AccessorListAccessor b)
        {
            if (ReferenceEquals(a, b))
                return true;
            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;
            if (a.m_ptr == b.m_ptr) return true;
            if (a.length != b.length) return false;
            return Memory.Compare(a.m_ptr, b.m_ptr, a.length);
        }
        public static bool operator !=(BTTKeyValuePair_AccessorListAccessor a, BTTKeyValuePair_AccessorListAccessor b)
        {
            return !(a == b);
        }
    }
}

namespace BTTN4KNFE
{
    
    public unsafe class BTTKeyValuePair_AccessorListAccessorListAccessor : IEnumerable<BTTKeyValuePair_AccessorListAccessor>
    {
        internal byte* m_ptr;
        internal long m_cellId;
        internal ResizeFunctionDelegate ResizeFunction;
        internal BTTKeyValuePair_AccessorListAccessorListAccessor(byte* _CellPtr, ResizeFunctionDelegate func)
        {
            m_ptr = _CellPtr;
            ResizeFunction = func;
            m_ptr += 4;
                    elementAccessor = new BTTKeyValuePair_AccessorListAccessor(null,
                (ptr,ptr_offset,delta)=>
                {
                    int substructure_offset = (int)(ptr - this.m_ptr);
                    this.m_ptr = this.ResizeFunction(this.m_ptr-sizeof(int), ptr_offset + substructure_offset +sizeof(int), delta);
                    *(int*)this.m_ptr += delta;
                    this.m_ptr += sizeof(int);
                    return this.m_ptr + substructure_offset;
                });
        }
        internal int length
        {
            get
            {
                return *(int*)(m_ptr - 4);
            }
        }
        BTTKeyValuePair_AccessorListAccessor elementAccessor;
        
        /// <summary>
        /// Gets the number of elements actually contained in the List. 
        /// </summary>";
        public unsafe int Count
        {
            get
            {
                
                byte* targetPtr = m_ptr;
                byte* endPtr = m_ptr + length;
                int ret = 0;
                while (targetPtr < endPtr)
                {
                    targetPtr += *(int*)targetPtr + sizeof(int);
                    ++ret;
                }
                return ret;
                
            }
        }
        /// <summary>
        /// Gets or sets the element at the specified index. 
        /// </summary>
        /// <param name="index">Given index</param>
        /// <returns>Corresponding element at the specified index</returns>";
        public unsafe BTTKeyValuePair_AccessorListAccessor this[int index]
        {
            get
            {
                
                {
                    
                    {
                        byte* targetPtr = m_ptr;
                        while (index-- > 0)
                        {
                            targetPtr += *(int*)targetPtr + sizeof(int);
                        }
                        
                        elementAccessor.m_ptr = targetPtr + 4;
                        
                    }
                    
                    elementAccessor.m_cellId = this.m_cellId;
                    return elementAccessor;
                }
                
            }
            set
            {
                
                {
                    if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                    elementAccessor.m_cellId = this.m_cellId;
                    byte* targetPtr = m_ptr;
                    
                    while (index-- > 0)
                    {
                        targetPtr += *(int*)targetPtr + sizeof(int);
                    }
                    
                int length = *(int*)(value.m_ptr - 4);
                int oldlength = *(int*)targetPtr;
                if (value.m_cellId != elementAccessor.m_cellId)
                {
                    //if not in the same Cell
                    elementAccessor.m_ptr = elementAccessor.ResizeFunction(targetPtr, 0, length - oldlength);
                    Memory.Copy(value.m_ptr - 4, elementAccessor.m_ptr, length + 4);
                }
                else
                {
                    byte[] tmpcell = new byte[length + 4];
                    fixed (byte* tmpcellptr = tmpcell)
                    {                        
                        Memory.Copy(value.m_ptr - 4, tmpcellptr, length + 4);
                        elementAccessor.m_ptr = elementAccessor.ResizeFunction(targetPtr, 0, length - oldlength);
                        Memory.Copy(tmpcellptr, elementAccessor.m_ptr, length + 4);
                    }
                }

                }
                
            }
        }
        /// <summary>
        /// Copies the elements to a new byte array
        /// </summary>
        /// <returns>Elements compactly arranged in a byte array.</returns>
        public unsafe byte[] ToByteArray()
        {
            byte[] ret = new byte[length];
            fixed (byte* retptr = ret)
            {
                Memory.Copy(m_ptr, retptr, length);
                return ret;
            }
        }
        /// <summary>
        /// Performs the specified action on each elements
        /// </summary>
        /// <param name="action">A lambda expression which has one parameter indicates element in List</param>
        public unsafe void ForEach(Action<BTTKeyValuePair_AccessorListAccessor> action)
        {
            byte* targetPtr = m_ptr;
            byte* endPtr = m_ptr + length;
            
            elementAccessor.m_cellId = this.m_cellId;
            
            while (targetPtr < endPtr)
            {
                
                {
                    elementAccessor.m_ptr = targetPtr + 4;
                    action(elementAccessor);
                    targetPtr += *(int*)targetPtr + sizeof(int);
                }
                
            }
        }
        /// <summary>
        /// Performs the specified action on each elements
        /// </summary>
        /// <param name="action">A lambda expression which has two parameters. First indicates element in the List and second the index of this element.</param>
        public unsafe void ForEach(Action<BTTKeyValuePair_AccessorListAccessor, int> action)
        {
            byte* targetPtr = m_ptr;
            byte* endPtr = m_ptr + length;
            for (int index = 0; targetPtr < endPtr; ++index)
            {
                
                {
                    elementAccessor.m_ptr = targetPtr + 4;
                    action(elementAccessor, index);
                    targetPtr += *(int*)targetPtr + sizeof(int);
                }
                
            }
        }
        internal unsafe struct _iterator
        {
            byte* targetPtr;
            byte* endPtr;
            BTTKeyValuePair_AccessorListAccessorListAccessor target;
            internal _iterator(BTTKeyValuePair_AccessorListAccessorListAccessor target)
            {
                targetPtr = target.m_ptr;
                endPtr = targetPtr + target.length;
                this.target = target;
            }
            internal bool good()
            {
                return (targetPtr < endPtr);
            }
            internal BTTKeyValuePair_AccessorListAccessor current()
            {
                
                {
                    target.elementAccessor.m_ptr = targetPtr + 4;
                    return target.elementAccessor;
                }
                
            }
            internal void move_next()
            {
                 
                {
                    targetPtr += *(int*)targetPtr + sizeof(int);
                }
                
            }
        }
        public IEnumerator<BTTKeyValuePair_AccessorListAccessor> GetEnumerator()
        {
            _iterator _it = new _iterator(this);
            while (_it.good())
            {
                yield return _it.current();
                _it.move_next();
            }
        }
        unsafe IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        /// <summary>
        /// Adds an item to the end of the List
        /// </summary>
        /// <param name="element">The object to be added to the end of the List.</param>
        public unsafe void Add(List<BTTKeyValuePair> element)
        {
            byte* targetPtr = null;
            {
                
{

    targetPtr += sizeof(int);
    if(element!= null)
    {
        for(int iterator_0 = 0;iterator_0<element.Count;++iterator_0)
        {

            {

        if(element[iterator_0].key!= null)
        {
            int strlen_2 = element[iterator_0].key.Length * 2;
            targetPtr += strlen_2+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(element[iterator_0].value!= null)
        {
            int strlen_2 = element[iterator_0].value.Length * 2;
            targetPtr += strlen_2+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
        }
    }

}

            }
            int size = (int)targetPtr;
            this.m_ptr = this.ResizeFunction(this.m_ptr - sizeof(int), *(int*)(this.m_ptr-sizeof(int))+sizeof(int), size);
            targetPtr = this.m_ptr + (*(int*)this.m_ptr)+sizeof(int);
            *(int*)this.m_ptr += size;
            this.m_ptr += sizeof(int);
            
{
byte *storedPtr_0 = targetPtr;

    targetPtr += sizeof(int);
    if(element!= null)
    {
        for(int iterator_0 = 0;iterator_0<element.Count;++iterator_0)
        {

            {

        if(element[iterator_0].key!= null)
        {
            int strlen_2 = element[iterator_0].key.Length * 2;
            *(int*)targetPtr = strlen_2;
            targetPtr += sizeof(int);
            fixed(char* pstr_2 = element[iterator_0].key)
            {
                Memory.Copy(pstr_2, targetPtr, strlen_2);
                targetPtr += strlen_2;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(element[iterator_0].value!= null)
        {
            int strlen_2 = element[iterator_0].value.Length * 2;
            *(int*)targetPtr = strlen_2;
            targetPtr += sizeof(int);
            fixed(char* pstr_2 = element[iterator_0].value)
            {
                Memory.Copy(pstr_2, targetPtr, strlen_2);
                targetPtr += strlen_2;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            }
        }
    }
*(int*)storedPtr_0 = (int)(targetPtr - storedPtr_0 - 4);

}

        }
        /// <summary>
        /// Inserts an element into the List at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index at which item should be inserted.</param>
        /// <param name="element">The object to insert.</param>
        public unsafe void Insert(int index, List<BTTKeyValuePair> element)
        {
            if (index < 0 || index > Count) throw new IndexOutOfRangeException();
            byte* targetPtr = null;
            {
                
{

    targetPtr += sizeof(int);
    if(element!= null)
    {
        for(int iterator_0 = 0;iterator_0<element.Count;++iterator_0)
        {

            {

        if(element[iterator_0].key!= null)
        {
            int strlen_2 = element[iterator_0].key.Length * 2;
            targetPtr += strlen_2+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(element[iterator_0].value!= null)
        {
            int strlen_2 = element[iterator_0].value.Length * 2;
            targetPtr += strlen_2+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
        }
    }

}

            }
            int size = (int)targetPtr;
            targetPtr = m_ptr;
            
            for (int i = 0; i < index; i++)
            {
                targetPtr += *(int*)targetPtr + sizeof(int);
            }
            
            int offset = (int)(targetPtr - m_ptr);
            this.m_ptr = this.ResizeFunction(this.m_ptr - sizeof(int), offset + sizeof(int), size);
            *(int*)this.m_ptr += size;
            this.m_ptr += sizeof(int);
            targetPtr = this.m_ptr + offset;
            
{
byte *storedPtr_0 = targetPtr;

    targetPtr += sizeof(int);
    if(element!= null)
    {
        for(int iterator_0 = 0;iterator_0<element.Count;++iterator_0)
        {

            {

        if(element[iterator_0].key!= null)
        {
            int strlen_2 = element[iterator_0].key.Length * 2;
            *(int*)targetPtr = strlen_2;
            targetPtr += sizeof(int);
            fixed(char* pstr_2 = element[iterator_0].key)
            {
                Memory.Copy(pstr_2, targetPtr, strlen_2);
                targetPtr += strlen_2;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(element[iterator_0].value!= null)
        {
            int strlen_2 = element[iterator_0].value.Length * 2;
            *(int*)targetPtr = strlen_2;
            targetPtr += sizeof(int);
            fixed(char* pstr_2 = element[iterator_0].value)
            {
                Memory.Copy(pstr_2, targetPtr, strlen_2);
                targetPtr += strlen_2;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            }
        }
    }
*(int*)storedPtr_0 = (int)(targetPtr - storedPtr_0 - 4);

}

        }
        /// <summary>
        /// Inserts an element into a sorted list.
        /// </summary>
        /// <param name="element">The object to insert.</param>
        /// <param name="comparison"></param>
        public unsafe void Insert(List<BTTKeyValuePair> element, Comparison<BTTKeyValuePair_AccessorListAccessor> comparison)
        {
            byte* targetPtr = null;
            {
                
{

    targetPtr += sizeof(int);
    if(element!= null)
    {
        for(int iterator_0 = 0;iterator_0<element.Count;++iterator_0)
        {

            {

        if(element[iterator_0].key!= null)
        {
            int strlen_2 = element[iterator_0].key.Length * 2;
            targetPtr += strlen_2+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(element[iterator_0].value!= null)
        {
            int strlen_2 = element[iterator_0].value.Length * 2;
            targetPtr += strlen_2+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
        }
    }

}

            }
            int size = (int)targetPtr;
            targetPtr = m_ptr;
            byte* endPtr = m_ptr + length;
            while (targetPtr<endPtr)
            {
                
            }
            int offset = (int)(targetPtr - m_ptr);
            this.m_ptr = this.ResizeFunction(this.m_ptr - sizeof(int), offset + sizeof(int), size);
            *(int*)this.m_ptr += size;
            this.m_ptr += sizeof(int);
            targetPtr = this.m_ptr + offset;
            
{
byte *storedPtr_0 = targetPtr;

    targetPtr += sizeof(int);
    if(element!= null)
    {
        for(int iterator_0 = 0;iterator_0<element.Count;++iterator_0)
        {

            {

        if(element[iterator_0].key!= null)
        {
            int strlen_2 = element[iterator_0].key.Length * 2;
            *(int*)targetPtr = strlen_2;
            targetPtr += sizeof(int);
            fixed(char* pstr_2 = element[iterator_0].key)
            {
                Memory.Copy(pstr_2, targetPtr, strlen_2);
                targetPtr += strlen_2;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(element[iterator_0].value!= null)
        {
            int strlen_2 = element[iterator_0].value.Length * 2;
            *(int*)targetPtr = strlen_2;
            targetPtr += sizeof(int);
            fixed(char* pstr_2 = element[iterator_0].value)
            {
                Memory.Copy(pstr_2, targetPtr, strlen_2);
                targetPtr += strlen_2;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            }
        }
    }
*(int*)storedPtr_0 = (int)(targetPtr - storedPtr_0 - 4);

}

        }
        /// <summary>
        /// Removes the element at the specified index of the List.
        /// </summary>
        /// <param name="index">The zero-based index of the element to remove.</param>
        public unsafe void RemoveAt(int index)
        {
            if (index < 0 || index >= Count) throw new IndexOutOfRangeException();
            byte* targetPtr = m_ptr;
            for (int i = 0; i < index; i++)
            {
                targetPtr += *(int*)targetPtr + sizeof(int);
            }
            int offset = (int)(targetPtr - m_ptr);
            byte* oldtargetPtr = targetPtr;
            targetPtr += *(int*)targetPtr + sizeof(int);
            int size = (int)(oldtargetPtr - targetPtr);
            this.m_ptr = this.ResizeFunction(this.m_ptr - sizeof(int), offset + sizeof(int), size);
            *(int*)this.m_ptr += size;
            this.m_ptr += sizeof(int);
        }
        /// <summary>
        /// Adds the elements of the specified collection to the end of the List
        /// </summary>
        /// <param name="collection">The collection whose elements should be added to the end of the List. The collection itself cannot be null.</param>
        public unsafe void AddRange(List<List<BTTKeyValuePair>> collection)
        {
            if (collection == null) throw new ArgumentNullException("collection is null.");
            BTTKeyValuePair_AccessorListAccessorListAccessor tcollection = collection;
            int delta = tcollection.length;
            m_ptr = ResizeFunction(m_ptr - 4, *(int*)(m_ptr - 4) + 4, delta);
            Memory.Copy(tcollection.m_ptr, m_ptr + *(int*)m_ptr + 4, delta);
            *(int*)m_ptr += delta;
            this.m_ptr += 4;
        }
        /// <summary>
        /// Adds the elements of the specified collection to the end of the List
        /// </summary>
        /// <param name="collection">The collection whose elements should be added to the end of the List. The collection itself cannot be null.</param>
        public unsafe void AddRange(BTTKeyValuePair_AccessorListAccessorListAccessor collection)
        {
            if (collection == null) throw new ArgumentNullException("collection is null.");
            int delta = collection.length;
            if (collection.m_cellId != m_cellId)
            {
                m_ptr = ResizeFunction(m_ptr - 4, *(int*)(m_ptr - 4) + 4, delta);
                Memory.Copy(collection.m_ptr, m_ptr + *(int*)m_ptr + 4, delta);
                *(int*)m_ptr += delta;
            }
            else
            {
                byte[] tmpcell = new byte[delta];
                fixed (byte* tmpcellptr = tmpcell)
                {
                    Memory.Copy(collection.m_ptr, tmpcellptr, delta);
                    m_ptr = ResizeFunction(m_ptr - 4, *(int*)(m_ptr - 4) + 4, delta);
                    Memory.Copy(tmpcellptr, m_ptr + *(int*)m_ptr + 4, delta);
                    *(int*)m_ptr += delta;
                }
            }
            this.m_ptr += 4;
        }
        /// <summary>
        /// Removes all elements from the List
        /// </summary>
        public unsafe void Clear()
        {
            int delta = length;
            Memory.memset(m_ptr, 0, (ulong)delta);
            m_ptr = ResizeFunction(m_ptr - 4, 4, -delta);
            *(int*)m_ptr = 0;
            this.m_ptr += 4;
        }
        /// <summary>
        /// Determines whether an element is in the List
        /// </summary>
        /// <param name="item">The object to locate in the List.The value can be null for non-atom types</param>
        /// <returns>true if item is found in the List; otherwise, false.</returns>
        public unsafe bool Contains(BTTKeyValuePair_AccessorListAccessor item)
        {
            bool ret = false;
            ForEach(x =>
            {
                if (item == x) ret = true;
            });
            return ret;
        }
        /// <summary>
        /// Determines whether the List contains elements that match the conditions defined by the specified predicate.
        /// </summary>
        /// <param name="match">The Predicate delegate that defines the conditions of the elements to search for.</param>
        /// <returns>true if the List contains one or more elements that match the conditions defined by the specified predicate; otherwise, false.</returns>
        public unsafe bool Exists(Predicate<BTTKeyValuePair_AccessorListAccessor> match)
        {
            bool ret = false;
            ForEach(x =>
            {
                if (match(x)) ret = true;
            });
            return ret;
        }
        
        /// <summary>
        /// Copies the entire List to a compatible one-dimensional array, starting at the beginning of the ptr1 array.
        /// </summary>
        /// <param name="array">The one-dimensional Array that is the destination of the elements copied from List. The Array must have zero-based indexing.</param>
        public unsafe void CopyTo(List<BTTKeyValuePair>[] array)
        {
            if (array == null) throw new ArgumentNullException("array is null.");
            if (array.Length < Count) throw new ArgumentException("The number of elements in the source List is greater than the number of elements that the destination array can contain.");
            ForEach((x, i) => array[i] = x);
        }
        /// <summary>
        /// Copies the entire List to a compatible one-dimensional array, starting at the specified index of the ptr1 array.
        /// </summary>
        /// <param name="array">The one-dimensional Array that is the destination of the elements copied from List. The Array must have zero-based indexing.</param>
        /// <param name="arrayIndex">The zero-based index in array at which copying begins.</param>
        public unsafe void CopyTo(List<BTTKeyValuePair>[] array, int arrayIndex)
        {
            if (array == null) throw new ArgumentNullException("array is null.");
            if (arrayIndex < 0) throw new ArgumentOutOfRangeException("arrayIndex is less than 0.");
            if (array.Length - arrayIndex < Count) throw new ArgumentException("The number of elements in the source List is greater than the available space from arrayIndex to the end of the destination array.");
            ForEach((x, i) => array[i + arrayIndex] = x);
        }
        /// <summary>
        /// Copies a range of elements from the List to a compatible one-dimensional array, starting at the specified index of the ptr1 array.
        /// </summary>
        /// <param name="index">The zero-based index in the source List at which copying begins.</param>
        /// <param name="array">The one-dimensional Array that is the destination of the elements copied from List. The Array must have zero-based indexing.</param>
        /// <param name="arrayIndex">The zero-based index in array at which copying begins.</param>;
        /// <param name="count">The number of elements to copy.</param>
        public unsafe void CopyTo(int index, List<BTTKeyValuePair>[] array, int arrayIndex, int count)
        {
            if (array == null) throw new ArgumentNullException("array is null.");
            if (arrayIndex < 0 || index < 0 || count < 0) throw new ArgumentOutOfRangeException("arrayIndex is less than 0 or index is less than 0 or count is less than 0.");
            if (array.Length - arrayIndex < count) throw new ArgumentException("The number of elements from index to the end of the source List is greater than the available space from arrayIndex to the end of the destination array. ");
            if (index + count > Count) throw new ArgumentException("Source list does not have enough elements to copy.");
            int j = 0;
            for (int i = index; i < index + count; i++)
            {
                array[j + arrayIndex] = this[i];
                ++j;
            }
        }
          
        /// <summary>
        /// Inserts the elements of a collection into the List at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index at which the new elements should be inserted.</param>
        /// <param name="collection">The collection whose elements should be inserted into the List. The collection itself cannot be null, but it can contain elements that are null, if type T is a reference type.</param>
        public unsafe void InsertRange(int index, List<List<BTTKeyValuePair>> collection)
        {
            if (collection == null) throw new ArgumentNullException("collection is null.");
            if (index < 0) throw new ArgumentOutOfRangeException("index is less than 0.");
            if (index > Count) throw new ArgumentOutOfRangeException("index is greater than Count.");
            BTTKeyValuePair_AccessorListAccessorListAccessor tmpAccessor = collection;
            byte* targetPtr = m_ptr;
            for (int i = 0; i < index; i++)
            {
                targetPtr += *(int*)targetPtr + sizeof(int);
            }
            int offset = (int)(targetPtr - m_ptr);
            m_ptr = ResizeFunction(m_ptr - 4, offset + 4, tmpAccessor.length);
            Memory.Copy(tmpAccessor.m_ptr, m_ptr + offset + 4, tmpAccessor.length);
            *(int*)m_ptr += tmpAccessor.length;
            this.m_ptr += 4;
        }
        /// <summary>
        /// Removes a range of elements from the List.
        /// </summary>
        /// <param name="index">The zero-based starting index of the range of elements to remove.</param>
        /// <param name="count">The number of elements to remove.</param>
        public unsafe void RemoveRange(int index, int count)
        {
            if (index < 0) throw new ArgumentOutOfRangeException("index is less than 0.");
            if (index > Count) throw new ArgumentOutOfRangeException("index is greater than Count.");
            if (index + count > Count) throw new ArgumentException("index and count do not denote a valid range of elements in the List.");
            byte* targetPtr = m_ptr;
            for (int i = 0; i < index; i++)
            {
                targetPtr += *(int*)targetPtr + sizeof(int);
            }
            int offset = (int)(targetPtr - m_ptr);
            byte* oldtargetPtr = targetPtr;
            for (int i = 0; i < count; i++)
            {
                targetPtr += *(int*)targetPtr + sizeof(int);
            }
            int size = (int)(oldtargetPtr - targetPtr);
            m_ptr = ResizeFunction(m_ptr - 4, offset + 4, size);
            *(int*)m_ptr += size;
            this.m_ptr += 4;
        }
        public unsafe static implicit operator List<List<BTTKeyValuePair>> (BTTKeyValuePair_AccessorListAccessorListAccessor accessor)
        {
            if((object)accessor == null) return null;
            List<List<BTTKeyValuePair>> list = new List<List<BTTKeyValuePair>>();
            accessor.ForEach(element => list.Add(element));
            return list;
        }
        
        public unsafe static implicit operator BTTKeyValuePair_AccessorListAccessorListAccessor(List<List<BTTKeyValuePair>> field)
        {
            byte* targetPtr = null;
            
{

    targetPtr += sizeof(int);
    if(field!= null)
    {
        for(int iterator_1 = 0;iterator_1<field.Count;++iterator_1)
        {

{

    targetPtr += sizeof(int);
    if(field[iterator_1]!= null)
    {
        for(int iterator_2 = 0;iterator_2<field[iterator_1].Count;++iterator_2)
        {

            {

        if(field[iterator_1][iterator_2].key!= null)
        {
            int strlen_4 = field[iterator_1][iterator_2].key.Length * 2;
            targetPtr += strlen_4+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(field[iterator_1][iterator_2].value!= null)
        {
            int strlen_4 = field[iterator_1][iterator_2].value.Length * 2;
            targetPtr += strlen_4+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
        }
    }

}

        }
    }

}

            byte* tmpcellptr = BufferAllocator.AllocBuffer((int)targetPtr);
            Memory.memset(tmpcellptr, 0, (ulong)targetPtr);
            targetPtr = tmpcellptr;
            
{
byte *storedPtr_1 = targetPtr;

    targetPtr += sizeof(int);
    if(field!= null)
    {
        for(int iterator_1 = 0;iterator_1<field.Count;++iterator_1)
        {

{
byte *storedPtr_2 = targetPtr;

    targetPtr += sizeof(int);
    if(field[iterator_1]!= null)
    {
        for(int iterator_2 = 0;iterator_2<field[iterator_1].Count;++iterator_2)
        {

            {

        if(field[iterator_1][iterator_2].key!= null)
        {
            int strlen_4 = field[iterator_1][iterator_2].key.Length * 2;
            *(int*)targetPtr = strlen_4;
            targetPtr += sizeof(int);
            fixed(char* pstr_4 = field[iterator_1][iterator_2].key)
            {
                Memory.Copy(pstr_4, targetPtr, strlen_4);
                targetPtr += strlen_4;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(field[iterator_1][iterator_2].value!= null)
        {
            int strlen_4 = field[iterator_1][iterator_2].value.Length * 2;
            *(int*)targetPtr = strlen_4;
            targetPtr += sizeof(int);
            fixed(char* pstr_4 = field[iterator_1][iterator_2].value)
            {
                Memory.Copy(pstr_4, targetPtr, strlen_4);
                targetPtr += strlen_4;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            }
        }
    }
*(int*)storedPtr_2 = (int)(targetPtr - storedPtr_2 - 4);

}

        }
    }
*(int*)storedPtr_1 = (int)(targetPtr - storedPtr_1 - 4);

}
BTTKeyValuePair_AccessorListAccessorListAccessor ret;
            
            ret = new BTTKeyValuePair_AccessorListAccessorListAccessor(tmpcellptr, null);
            
            return ret;
        }
        
        public static bool operator ==(BTTKeyValuePair_AccessorListAccessorListAccessor a, BTTKeyValuePair_AccessorListAccessorListAccessor b)
        {
            if (ReferenceEquals(a, b))
                return true;
            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;
            if (a.m_ptr == b.m_ptr) return true;
            if (a.length != b.length) return false;
            return Memory.Compare(a.m_ptr, b.m_ptr, a.length);
        }
        public static bool operator !=(BTTKeyValuePair_AccessorListAccessorListAccessor a, BTTKeyValuePair_AccessorListAccessorListAccessor b)
        {
            return !(a == b);
        }
    }
}

namespace BTTN4KNFE
{
    
    public unsafe class BTTClaim_AccessorListAccessor : IEnumerable<BTTClaim_Accessor>
    {
        internal byte* m_ptr;
        internal long m_cellId;
        internal ResizeFunctionDelegate ResizeFunction;
        internal BTTClaim_AccessorListAccessor(byte* _CellPtr, ResizeFunctionDelegate func)
        {
            m_ptr = _CellPtr;
            ResizeFunction = func;
            m_ptr += 4;
                    elementAccessor = new BTTClaim_Accessor(null,
                (ptr,ptr_offset,delta)=>
                {
                    int substructure_offset = (int)(ptr - this.m_ptr);
                    this.m_ptr = this.ResizeFunction(this.m_ptr-sizeof(int), ptr_offset + substructure_offset +sizeof(int), delta);
                    *(int*)this.m_ptr += delta;
                    this.m_ptr += sizeof(int);
                    return this.m_ptr + substructure_offset;
                });
        }
        internal int length
        {
            get
            {
                return *(int*)(m_ptr - 4);
            }
        }
        BTTClaim_Accessor elementAccessor;
        
        /// <summary>
        /// Gets the number of elements actually contained in the List. 
        /// </summary>";
        public unsafe int Count
        {
            get
            {
                
                byte* targetPtr = m_ptr;
                byte* endPtr = m_ptr + length;
                int ret = 0;
                while (targetPtr < endPtr)
                {
                    {            byte* optheader_1 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_1 + 0) & 0x01)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }

                if ((0 != (*(optheader_1 + 0) & 0x02)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }

                if ((0 != (*(optheader_1 + 0) & 0x04)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }
}
                    ++ret;
                }
                return ret;
                
            }
        }
        /// <summary>
        /// Gets or sets the element at the specified index. 
        /// </summary>
        /// <param name="index">Given index</param>
        /// <returns>Corresponding element at the specified index</returns>";
        public unsafe BTTClaim_Accessor this[int index]
        {
            get
            {
                
                {
                    
                    {
                        byte* targetPtr = m_ptr;
                        while (index-- > 0)
                        {
                            {            byte* optheader_1 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_1 + 0) & 0x01)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }

                if ((0 != (*(optheader_1 + 0) & 0x02)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }

                if ((0 != (*(optheader_1 + 0) & 0x04)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }
}
                        }
                        
                        elementAccessor.m_ptr = targetPtr;
                        
                    }
                    
                    elementAccessor.m_cellId = this.m_cellId;
                    return elementAccessor;
                }
                
            }
            set
            {
                
                {
                    if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                    elementAccessor.m_cellId = this.m_cellId;
                    byte* targetPtr = m_ptr;
                    
                    while (index-- > 0)
                    {
                        {            byte* optheader_1 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_1 + 0) & 0x01)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }

                if ((0 != (*(optheader_1 + 0) & 0x02)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }

                if ((0 != (*(optheader_1 + 0) & 0x04)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }
}
                    }
                    
                int offset = (int)(targetPtr - m_ptr);
                byte* oldtargetPtr = targetPtr;
                int oldlength = (int)(targetPtr - oldtargetPtr);
                targetPtr = value.m_ptr;
                int newlength = (int)(targetPtr - value.m_ptr);
                if (newlength != oldlength)
                {
                    if (value.m_cellId != this.m_cellId)
                    {
                        this.m_ptr = this.ResizeFunction(this.m_ptr, offset, newlength - oldlength);
                        Memory.Copy(value.m_ptr, this.m_ptr + offset, newlength);
                    }
                    else
                    {
                        byte[] tmpcell = new byte[newlength];
                        fixed(byte* tmpcellptr = tmpcell)
                        {
                            Memory.Copy(value.m_ptr, tmpcellptr, newlength);
                            this.m_ptr = this.ResizeFunction(this.m_ptr, offset, newlength - oldlength);
                            Memory.Copy(tmpcellptr, this.m_ptr + offset, newlength);
                        }
                    }
                }
                else
                {
                    Memory.Copy(value.m_ptr, oldtargetPtr, oldlength);
                }
                }
                
            }
        }
        /// <summary>
        /// Copies the elements to a new byte array
        /// </summary>
        /// <returns>Elements compactly arranged in a byte array.</returns>
        public unsafe byte[] ToByteArray()
        {
            byte[] ret = new byte[length];
            fixed (byte* retptr = ret)
            {
                Memory.Copy(m_ptr, retptr, length);
                return ret;
            }
        }
        /// <summary>
        /// Performs the specified action on each elements
        /// </summary>
        /// <param name="action">A lambda expression which has one parameter indicates element in List</param>
        public unsafe void ForEach(Action<BTTClaim_Accessor> action)
        {
            byte* targetPtr = m_ptr;
            byte* endPtr = m_ptr + length;
            
            elementAccessor.m_cellId = this.m_cellId;
            
            while (targetPtr < endPtr)
            {
                
                {
                    elementAccessor.m_ptr = targetPtr;
                    action(elementAccessor);
                    {            byte* optheader_1 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_1 + 0) & 0x01)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }

                if ((0 != (*(optheader_1 + 0) & 0x02)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }

                if ((0 != (*(optheader_1 + 0) & 0x04)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }
}
                }
                
            }
        }
        /// <summary>
        /// Performs the specified action on each elements
        /// </summary>
        /// <param name="action">A lambda expression which has two parameters. First indicates element in the List and second the index of this element.</param>
        public unsafe void ForEach(Action<BTTClaim_Accessor, int> action)
        {
            byte* targetPtr = m_ptr;
            byte* endPtr = m_ptr + length;
            for (int index = 0; targetPtr < endPtr; ++index)
            {
                
                {
                    elementAccessor.m_ptr = targetPtr;
                    action(elementAccessor, index);
                    {            byte* optheader_1 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_1 + 0) & 0x01)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }

                if ((0 != (*(optheader_1 + 0) & 0x02)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }

                if ((0 != (*(optheader_1 + 0) & 0x04)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }
}
                }
                
            }
        }
        internal unsafe struct _iterator
        {
            byte* targetPtr;
            byte* endPtr;
            BTTClaim_AccessorListAccessor target;
            internal _iterator(BTTClaim_AccessorListAccessor target)
            {
                targetPtr = target.m_ptr;
                endPtr = targetPtr + target.length;
                this.target = target;
            }
            internal bool good()
            {
                return (targetPtr < endPtr);
            }
            internal BTTClaim_Accessor current()
            {
                
                {
                    target.elementAccessor.m_ptr = targetPtr;
                    return target.elementAccessor;
                }
                
            }
            internal void move_next()
            {
                 
                {
                    {            byte* optheader_1 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_1 + 0) & 0x01)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }

                if ((0 != (*(optheader_1 + 0) & 0x02)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }

                if ((0 != (*(optheader_1 + 0) & 0x04)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }
}
                }
                
            }
        }
        public IEnumerator<BTTClaim_Accessor> GetEnumerator()
        {
            _iterator _it = new _iterator(this);
            while (_it.good())
            {
                yield return _it.current();
                _it.move_next();
            }
        }
        unsafe IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        /// <summary>
        /// Adds an item to the end of the List
        /// </summary>
        /// <param name="element">The object to be added to the end of the List.</param>
        public unsafe void Add(BTTClaim element)
        {
            byte* targetPtr = null;
            {
                
            {
            targetPtr += 1;

        if(element.key!= null)
        {
            int strlen_1 = element.key.Length * 2;
            targetPtr += strlen_1+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            if( element.value!= null)
            {

        if(element.value!= null)
        {
            int strlen_1 = element.value.Length * 2;
            targetPtr += strlen_1+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
            if( element.attribute!= null)
            {

{

    targetPtr += sizeof(int);
    if(element.attribute!= null)
    {
        for(int iterator_1 = 0;iterator_1<element.attribute.Count;++iterator_1)
        {

            {

        if(element.attribute[iterator_1].key!= null)
        {
            int strlen_3 = element.attribute[iterator_1].key.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(element.attribute[iterator_1].value!= null)
        {
            int strlen_3 = element.attribute[iterator_1].value.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
        }
    }

}

            }
            if( element.attributes!= null)
            {

{

    targetPtr += sizeof(int);
    if(element.attributes!= null)
    {
        for(int iterator_1 = 0;iterator_1<element.attributes.Count;++iterator_1)
        {

{

    targetPtr += sizeof(int);
    if(element.attributes[iterator_1]!= null)
    {
        for(int iterator_2 = 0;iterator_2<element.attributes[iterator_1].Count;++iterator_2)
        {

            {

        if(element.attributes[iterator_1][iterator_2].key!= null)
        {
            int strlen_4 = element.attributes[iterator_1][iterator_2].key.Length * 2;
            targetPtr += strlen_4+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(element.attributes[iterator_1][iterator_2].value!= null)
        {
            int strlen_4 = element.attributes[iterator_1][iterator_2].value.Length * 2;
            targetPtr += strlen_4+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
        }
    }

}

        }
    }

}

            }

            }
            }
            int size = (int)targetPtr;
            this.m_ptr = this.ResizeFunction(this.m_ptr - sizeof(int), *(int*)(this.m_ptr-sizeof(int))+sizeof(int), size);
            targetPtr = this.m_ptr + (*(int*)this.m_ptr)+sizeof(int);
            *(int*)this.m_ptr += size;
            this.m_ptr += sizeof(int);
            
            {
            byte* optheader_0 = targetPtr;
            *(optheader_0 + 0) = 0x00;            targetPtr += 1;

        if(element.key!= null)
        {
            int strlen_1 = element.key.Length * 2;
            *(int*)targetPtr = strlen_1;
            targetPtr += sizeof(int);
            fixed(char* pstr_1 = element.key)
            {
                Memory.Copy(pstr_1, targetPtr, strlen_1);
                targetPtr += strlen_1;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            if( element.value!= null)
            {

        if(element.value!= null)
        {
            int strlen_1 = element.value.Length * 2;
            *(int*)targetPtr = strlen_1;
            targetPtr += sizeof(int);
            fixed(char* pstr_1 = element.value)
            {
                Memory.Copy(pstr_1, targetPtr, strlen_1);
                targetPtr += strlen_1;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
*(optheader_0 + 0) |= 0x01;
            }
            if( element.attribute!= null)
            {

{
byte *storedPtr_1 = targetPtr;

    targetPtr += sizeof(int);
    if(element.attribute!= null)
    {
        for(int iterator_1 = 0;iterator_1<element.attribute.Count;++iterator_1)
        {

            {

        if(element.attribute[iterator_1].key!= null)
        {
            int strlen_3 = element.attribute[iterator_1].key.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = element.attribute[iterator_1].key)
            {
                Memory.Copy(pstr_3, targetPtr, strlen_3);
                targetPtr += strlen_3;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(element.attribute[iterator_1].value!= null)
        {
            int strlen_3 = element.attribute[iterator_1].value.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = element.attribute[iterator_1].value)
            {
                Memory.Copy(pstr_3, targetPtr, strlen_3);
                targetPtr += strlen_3;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            }
        }
    }
*(int*)storedPtr_1 = (int)(targetPtr - storedPtr_1 - 4);

}
*(optheader_0 + 0) |= 0x02;
            }
            if( element.attributes!= null)
            {

{
byte *storedPtr_1 = targetPtr;

    targetPtr += sizeof(int);
    if(element.attributes!= null)
    {
        for(int iterator_1 = 0;iterator_1<element.attributes.Count;++iterator_1)
        {

{
byte *storedPtr_2 = targetPtr;

    targetPtr += sizeof(int);
    if(element.attributes[iterator_1]!= null)
    {
        for(int iterator_2 = 0;iterator_2<element.attributes[iterator_1].Count;++iterator_2)
        {

            {

        if(element.attributes[iterator_1][iterator_2].key!= null)
        {
            int strlen_4 = element.attributes[iterator_1][iterator_2].key.Length * 2;
            *(int*)targetPtr = strlen_4;
            targetPtr += sizeof(int);
            fixed(char* pstr_4 = element.attributes[iterator_1][iterator_2].key)
            {
                Memory.Copy(pstr_4, targetPtr, strlen_4);
                targetPtr += strlen_4;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(element.attributes[iterator_1][iterator_2].value!= null)
        {
            int strlen_4 = element.attributes[iterator_1][iterator_2].value.Length * 2;
            *(int*)targetPtr = strlen_4;
            targetPtr += sizeof(int);
            fixed(char* pstr_4 = element.attributes[iterator_1][iterator_2].value)
            {
                Memory.Copy(pstr_4, targetPtr, strlen_4);
                targetPtr += strlen_4;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            }
        }
    }
*(int*)storedPtr_2 = (int)(targetPtr - storedPtr_2 - 4);

}

        }
    }
*(int*)storedPtr_1 = (int)(targetPtr - storedPtr_1 - 4);

}
*(optheader_0 + 0) |= 0x04;
            }

            }
        }
        /// <summary>
        /// Inserts an element into the List at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index at which item should be inserted.</param>
        /// <param name="element">The object to insert.</param>
        public unsafe void Insert(int index, BTTClaim element)
        {
            if (index < 0 || index > Count) throw new IndexOutOfRangeException();
            byte* targetPtr = null;
            {
                
            {
            targetPtr += 1;

        if(element.key!= null)
        {
            int strlen_1 = element.key.Length * 2;
            targetPtr += strlen_1+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            if( element.value!= null)
            {

        if(element.value!= null)
        {
            int strlen_1 = element.value.Length * 2;
            targetPtr += strlen_1+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
            if( element.attribute!= null)
            {

{

    targetPtr += sizeof(int);
    if(element.attribute!= null)
    {
        for(int iterator_1 = 0;iterator_1<element.attribute.Count;++iterator_1)
        {

            {

        if(element.attribute[iterator_1].key!= null)
        {
            int strlen_3 = element.attribute[iterator_1].key.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(element.attribute[iterator_1].value!= null)
        {
            int strlen_3 = element.attribute[iterator_1].value.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
        }
    }

}

            }
            if( element.attributes!= null)
            {

{

    targetPtr += sizeof(int);
    if(element.attributes!= null)
    {
        for(int iterator_1 = 0;iterator_1<element.attributes.Count;++iterator_1)
        {

{

    targetPtr += sizeof(int);
    if(element.attributes[iterator_1]!= null)
    {
        for(int iterator_2 = 0;iterator_2<element.attributes[iterator_1].Count;++iterator_2)
        {

            {

        if(element.attributes[iterator_1][iterator_2].key!= null)
        {
            int strlen_4 = element.attributes[iterator_1][iterator_2].key.Length * 2;
            targetPtr += strlen_4+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(element.attributes[iterator_1][iterator_2].value!= null)
        {
            int strlen_4 = element.attributes[iterator_1][iterator_2].value.Length * 2;
            targetPtr += strlen_4+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
        }
    }

}

        }
    }

}

            }

            }
            }
            int size = (int)targetPtr;
            targetPtr = m_ptr;
            
            for (int i = 0; i < index; i++)
            {
                {            byte* optheader_1 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_1 + 0) & 0x01)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }

                if ((0 != (*(optheader_1 + 0) & 0x02)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }

                if ((0 != (*(optheader_1 + 0) & 0x04)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }
}
            }
            
            int offset = (int)(targetPtr - m_ptr);
            this.m_ptr = this.ResizeFunction(this.m_ptr - sizeof(int), offset + sizeof(int), size);
            *(int*)this.m_ptr += size;
            this.m_ptr += sizeof(int);
            targetPtr = this.m_ptr + offset;
            
            {
            byte* optheader_0 = targetPtr;
            *(optheader_0 + 0) = 0x00;            targetPtr += 1;

        if(element.key!= null)
        {
            int strlen_1 = element.key.Length * 2;
            *(int*)targetPtr = strlen_1;
            targetPtr += sizeof(int);
            fixed(char* pstr_1 = element.key)
            {
                Memory.Copy(pstr_1, targetPtr, strlen_1);
                targetPtr += strlen_1;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            if( element.value!= null)
            {

        if(element.value!= null)
        {
            int strlen_1 = element.value.Length * 2;
            *(int*)targetPtr = strlen_1;
            targetPtr += sizeof(int);
            fixed(char* pstr_1 = element.value)
            {
                Memory.Copy(pstr_1, targetPtr, strlen_1);
                targetPtr += strlen_1;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
*(optheader_0 + 0) |= 0x01;
            }
            if( element.attribute!= null)
            {

{
byte *storedPtr_1 = targetPtr;

    targetPtr += sizeof(int);
    if(element.attribute!= null)
    {
        for(int iterator_1 = 0;iterator_1<element.attribute.Count;++iterator_1)
        {

            {

        if(element.attribute[iterator_1].key!= null)
        {
            int strlen_3 = element.attribute[iterator_1].key.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = element.attribute[iterator_1].key)
            {
                Memory.Copy(pstr_3, targetPtr, strlen_3);
                targetPtr += strlen_3;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(element.attribute[iterator_1].value!= null)
        {
            int strlen_3 = element.attribute[iterator_1].value.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = element.attribute[iterator_1].value)
            {
                Memory.Copy(pstr_3, targetPtr, strlen_3);
                targetPtr += strlen_3;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            }
        }
    }
*(int*)storedPtr_1 = (int)(targetPtr - storedPtr_1 - 4);

}
*(optheader_0 + 0) |= 0x02;
            }
            if( element.attributes!= null)
            {

{
byte *storedPtr_1 = targetPtr;

    targetPtr += sizeof(int);
    if(element.attributes!= null)
    {
        for(int iterator_1 = 0;iterator_1<element.attributes.Count;++iterator_1)
        {

{
byte *storedPtr_2 = targetPtr;

    targetPtr += sizeof(int);
    if(element.attributes[iterator_1]!= null)
    {
        for(int iterator_2 = 0;iterator_2<element.attributes[iterator_1].Count;++iterator_2)
        {

            {

        if(element.attributes[iterator_1][iterator_2].key!= null)
        {
            int strlen_4 = element.attributes[iterator_1][iterator_2].key.Length * 2;
            *(int*)targetPtr = strlen_4;
            targetPtr += sizeof(int);
            fixed(char* pstr_4 = element.attributes[iterator_1][iterator_2].key)
            {
                Memory.Copy(pstr_4, targetPtr, strlen_4);
                targetPtr += strlen_4;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(element.attributes[iterator_1][iterator_2].value!= null)
        {
            int strlen_4 = element.attributes[iterator_1][iterator_2].value.Length * 2;
            *(int*)targetPtr = strlen_4;
            targetPtr += sizeof(int);
            fixed(char* pstr_4 = element.attributes[iterator_1][iterator_2].value)
            {
                Memory.Copy(pstr_4, targetPtr, strlen_4);
                targetPtr += strlen_4;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            }
        }
    }
*(int*)storedPtr_2 = (int)(targetPtr - storedPtr_2 - 4);

}

        }
    }
*(int*)storedPtr_1 = (int)(targetPtr - storedPtr_1 - 4);

}
*(optheader_0 + 0) |= 0x04;
            }

            }
        }
        /// <summary>
        /// Inserts an element into a sorted list.
        /// </summary>
        /// <param name="element">The object to insert.</param>
        /// <param name="comparison"></param>
        public unsafe void Insert(BTTClaim element, Comparison<BTTClaim_Accessor> comparison)
        {
            byte* targetPtr = null;
            {
                
            {
            targetPtr += 1;

        if(element.key!= null)
        {
            int strlen_1 = element.key.Length * 2;
            targetPtr += strlen_1+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            if( element.value!= null)
            {

        if(element.value!= null)
        {
            int strlen_1 = element.value.Length * 2;
            targetPtr += strlen_1+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
            if( element.attribute!= null)
            {

{

    targetPtr += sizeof(int);
    if(element.attribute!= null)
    {
        for(int iterator_1 = 0;iterator_1<element.attribute.Count;++iterator_1)
        {

            {

        if(element.attribute[iterator_1].key!= null)
        {
            int strlen_3 = element.attribute[iterator_1].key.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(element.attribute[iterator_1].value!= null)
        {
            int strlen_3 = element.attribute[iterator_1].value.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
        }
    }

}

            }
            if( element.attributes!= null)
            {

{

    targetPtr += sizeof(int);
    if(element.attributes!= null)
    {
        for(int iterator_1 = 0;iterator_1<element.attributes.Count;++iterator_1)
        {

{

    targetPtr += sizeof(int);
    if(element.attributes[iterator_1]!= null)
    {
        for(int iterator_2 = 0;iterator_2<element.attributes[iterator_1].Count;++iterator_2)
        {

            {

        if(element.attributes[iterator_1][iterator_2].key!= null)
        {
            int strlen_4 = element.attributes[iterator_1][iterator_2].key.Length * 2;
            targetPtr += strlen_4+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(element.attributes[iterator_1][iterator_2].value!= null)
        {
            int strlen_4 = element.attributes[iterator_1][iterator_2].value.Length * 2;
            targetPtr += strlen_4+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
        }
    }

}

        }
    }

}

            }

            }
            }
            int size = (int)targetPtr;
            targetPtr = m_ptr;
            byte* endPtr = m_ptr + length;
            while (targetPtr<endPtr)
            {
                
                {
                    elementAccessor.m_ptr = targetPtr + 4;
                    if (comparison(elementAccessor, element)<=0)
                    {
                        {            byte* optheader_1 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_1 + 0) & 0x01)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }

                if ((0 != (*(optheader_1 + 0) & 0x02)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }

                if ((0 != (*(optheader_1 + 0) & 0x04)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }
}
                    }
                    else
                    {
                        break;
                    }
                }
                
            }
            int offset = (int)(targetPtr - m_ptr);
            this.m_ptr = this.ResizeFunction(this.m_ptr - sizeof(int), offset + sizeof(int), size);
            *(int*)this.m_ptr += size;
            this.m_ptr += sizeof(int);
            targetPtr = this.m_ptr + offset;
            
            {
            byte* optheader_0 = targetPtr;
            *(optheader_0 + 0) = 0x00;            targetPtr += 1;

        if(element.key!= null)
        {
            int strlen_1 = element.key.Length * 2;
            *(int*)targetPtr = strlen_1;
            targetPtr += sizeof(int);
            fixed(char* pstr_1 = element.key)
            {
                Memory.Copy(pstr_1, targetPtr, strlen_1);
                targetPtr += strlen_1;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            if( element.value!= null)
            {

        if(element.value!= null)
        {
            int strlen_1 = element.value.Length * 2;
            *(int*)targetPtr = strlen_1;
            targetPtr += sizeof(int);
            fixed(char* pstr_1 = element.value)
            {
                Memory.Copy(pstr_1, targetPtr, strlen_1);
                targetPtr += strlen_1;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
*(optheader_0 + 0) |= 0x01;
            }
            if( element.attribute!= null)
            {

{
byte *storedPtr_1 = targetPtr;

    targetPtr += sizeof(int);
    if(element.attribute!= null)
    {
        for(int iterator_1 = 0;iterator_1<element.attribute.Count;++iterator_1)
        {

            {

        if(element.attribute[iterator_1].key!= null)
        {
            int strlen_3 = element.attribute[iterator_1].key.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = element.attribute[iterator_1].key)
            {
                Memory.Copy(pstr_3, targetPtr, strlen_3);
                targetPtr += strlen_3;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(element.attribute[iterator_1].value!= null)
        {
            int strlen_3 = element.attribute[iterator_1].value.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = element.attribute[iterator_1].value)
            {
                Memory.Copy(pstr_3, targetPtr, strlen_3);
                targetPtr += strlen_3;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            }
        }
    }
*(int*)storedPtr_1 = (int)(targetPtr - storedPtr_1 - 4);

}
*(optheader_0 + 0) |= 0x02;
            }
            if( element.attributes!= null)
            {

{
byte *storedPtr_1 = targetPtr;

    targetPtr += sizeof(int);
    if(element.attributes!= null)
    {
        for(int iterator_1 = 0;iterator_1<element.attributes.Count;++iterator_1)
        {

{
byte *storedPtr_2 = targetPtr;

    targetPtr += sizeof(int);
    if(element.attributes[iterator_1]!= null)
    {
        for(int iterator_2 = 0;iterator_2<element.attributes[iterator_1].Count;++iterator_2)
        {

            {

        if(element.attributes[iterator_1][iterator_2].key!= null)
        {
            int strlen_4 = element.attributes[iterator_1][iterator_2].key.Length * 2;
            *(int*)targetPtr = strlen_4;
            targetPtr += sizeof(int);
            fixed(char* pstr_4 = element.attributes[iterator_1][iterator_2].key)
            {
                Memory.Copy(pstr_4, targetPtr, strlen_4);
                targetPtr += strlen_4;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(element.attributes[iterator_1][iterator_2].value!= null)
        {
            int strlen_4 = element.attributes[iterator_1][iterator_2].value.Length * 2;
            *(int*)targetPtr = strlen_4;
            targetPtr += sizeof(int);
            fixed(char* pstr_4 = element.attributes[iterator_1][iterator_2].value)
            {
                Memory.Copy(pstr_4, targetPtr, strlen_4);
                targetPtr += strlen_4;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            }
        }
    }
*(int*)storedPtr_2 = (int)(targetPtr - storedPtr_2 - 4);

}

        }
    }
*(int*)storedPtr_1 = (int)(targetPtr - storedPtr_1 - 4);

}
*(optheader_0 + 0) |= 0x04;
            }

            }
        }
        /// <summary>
        /// Removes the element at the specified index of the List.
        /// </summary>
        /// <param name="index">The zero-based index of the element to remove.</param>
        public unsafe void RemoveAt(int index)
        {
            if (index < 0 || index >= Count) throw new IndexOutOfRangeException();
            byte* targetPtr = m_ptr;
            for (int i = 0; i < index; i++)
            {
                {            byte* optheader_1 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_1 + 0) & 0x01)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }

                if ((0 != (*(optheader_1 + 0) & 0x02)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }

                if ((0 != (*(optheader_1 + 0) & 0x04)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }
}
            }
            int offset = (int)(targetPtr - m_ptr);
            byte* oldtargetPtr = targetPtr;
            {            byte* optheader_1 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_1 + 0) & 0x01)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }

                if ((0 != (*(optheader_1 + 0) & 0x02)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }

                if ((0 != (*(optheader_1 + 0) & 0x04)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }
}
            int size = (int)(oldtargetPtr - targetPtr);
            this.m_ptr = this.ResizeFunction(this.m_ptr - sizeof(int), offset + sizeof(int), size);
            *(int*)this.m_ptr += size;
            this.m_ptr += sizeof(int);
        }
        /// <summary>
        /// Adds the elements of the specified collection to the end of the List
        /// </summary>
        /// <param name="collection">The collection whose elements should be added to the end of the List. The collection itself cannot be null.</param>
        public unsafe void AddRange(List<BTTClaim> collection)
        {
            if (collection == null) throw new ArgumentNullException("collection is null.");
            BTTClaim_AccessorListAccessor tcollection = collection;
            int delta = tcollection.length;
            m_ptr = ResizeFunction(m_ptr - 4, *(int*)(m_ptr - 4) + 4, delta);
            Memory.Copy(tcollection.m_ptr, m_ptr + *(int*)m_ptr + 4, delta);
            *(int*)m_ptr += delta;
            this.m_ptr += 4;
        }
        /// <summary>
        /// Adds the elements of the specified collection to the end of the List
        /// </summary>
        /// <param name="collection">The collection whose elements should be added to the end of the List. The collection itself cannot be null.</param>
        public unsafe void AddRange(BTTClaim_AccessorListAccessor collection)
        {
            if (collection == null) throw new ArgumentNullException("collection is null.");
            int delta = collection.length;
            if (collection.m_cellId != m_cellId)
            {
                m_ptr = ResizeFunction(m_ptr - 4, *(int*)(m_ptr - 4) + 4, delta);
                Memory.Copy(collection.m_ptr, m_ptr + *(int*)m_ptr + 4, delta);
                *(int*)m_ptr += delta;
            }
            else
            {
                byte[] tmpcell = new byte[delta];
                fixed (byte* tmpcellptr = tmpcell)
                {
                    Memory.Copy(collection.m_ptr, tmpcellptr, delta);
                    m_ptr = ResizeFunction(m_ptr - 4, *(int*)(m_ptr - 4) + 4, delta);
                    Memory.Copy(tmpcellptr, m_ptr + *(int*)m_ptr + 4, delta);
                    *(int*)m_ptr += delta;
                }
            }
            this.m_ptr += 4;
        }
        /// <summary>
        /// Removes all elements from the List
        /// </summary>
        public unsafe void Clear()
        {
            int delta = length;
            Memory.memset(m_ptr, 0, (ulong)delta);
            m_ptr = ResizeFunction(m_ptr - 4, 4, -delta);
            *(int*)m_ptr = 0;
            this.m_ptr += 4;
        }
        /// <summary>
        /// Determines whether an element is in the List
        /// </summary>
        /// <param name="item">The object to locate in the List.The value can be null for non-atom types</param>
        /// <returns>true if item is found in the List; otherwise, false.</returns>
        public unsafe bool Contains(BTTClaim_Accessor item)
        {
            bool ret = false;
            ForEach(x =>
            {
                if (item == x) ret = true;
            });
            return ret;
        }
        /// <summary>
        /// Determines whether the List contains elements that match the conditions defined by the specified predicate.
        /// </summary>
        /// <param name="match">The Predicate delegate that defines the conditions of the elements to search for.</param>
        /// <returns>true if the List contains one or more elements that match the conditions defined by the specified predicate; otherwise, false.</returns>
        public unsafe bool Exists(Predicate<BTTClaim_Accessor> match)
        {
            bool ret = false;
            ForEach(x =>
            {
                if (match(x)) ret = true;
            });
            return ret;
        }
        
        /// <summary>
        /// Copies the entire List to a compatible one-dimensional array, starting at the beginning of the ptr1 array.
        /// </summary>
        /// <param name="array">The one-dimensional Array that is the destination of the elements copied from List. The Array must have zero-based indexing.</param>
        public unsafe void CopyTo(BTTClaim[] array)
        {
            if (array == null) throw new ArgumentNullException("array is null.");
            if (array.Length < Count) throw new ArgumentException("The number of elements in the source List is greater than the number of elements that the destination array can contain.");
            ForEach((x, i) => array[i] = x);
        }
        /// <summary>
        /// Copies the entire List to a compatible one-dimensional array, starting at the specified index of the ptr1 array.
        /// </summary>
        /// <param name="array">The one-dimensional Array that is the destination of the elements copied from List. The Array must have zero-based indexing.</param>
        /// <param name="arrayIndex">The zero-based index in array at which copying begins.</param>
        public unsafe void CopyTo(BTTClaim[] array, int arrayIndex)
        {
            if (array == null) throw new ArgumentNullException("array is null.");
            if (arrayIndex < 0) throw new ArgumentOutOfRangeException("arrayIndex is less than 0.");
            if (array.Length - arrayIndex < Count) throw new ArgumentException("The number of elements in the source List is greater than the available space from arrayIndex to the end of the destination array.");
            ForEach((x, i) => array[i + arrayIndex] = x);
        }
        /// <summary>
        /// Copies a range of elements from the List to a compatible one-dimensional array, starting at the specified index of the ptr1 array.
        /// </summary>
        /// <param name="index">The zero-based index in the source List at which copying begins.</param>
        /// <param name="array">The one-dimensional Array that is the destination of the elements copied from List. The Array must have zero-based indexing.</param>
        /// <param name="arrayIndex">The zero-based index in array at which copying begins.</param>;
        /// <param name="count">The number of elements to copy.</param>
        public unsafe void CopyTo(int index, BTTClaim[] array, int arrayIndex, int count)
        {
            if (array == null) throw new ArgumentNullException("array is null.");
            if (arrayIndex < 0 || index < 0 || count < 0) throw new ArgumentOutOfRangeException("arrayIndex is less than 0 or index is less than 0 or count is less than 0.");
            if (array.Length - arrayIndex < count) throw new ArgumentException("The number of elements from index to the end of the source List is greater than the available space from arrayIndex to the end of the destination array. ");
            if (index + count > Count) throw new ArgumentException("Source list does not have enough elements to copy.");
            int j = 0;
            for (int i = index; i < index + count; i++)
            {
                array[j + arrayIndex] = this[i];
                ++j;
            }
        }
          
        /// <summary>
        /// Inserts the elements of a collection into the List at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index at which the new elements should be inserted.</param>
        /// <param name="collection">The collection whose elements should be inserted into the List. The collection itself cannot be null, but it can contain elements that are null, if type T is a reference type.</param>
        public unsafe void InsertRange(int index, List<BTTClaim> collection)
        {
            if (collection == null) throw new ArgumentNullException("collection is null.");
            if (index < 0) throw new ArgumentOutOfRangeException("index is less than 0.");
            if (index > Count) throw new ArgumentOutOfRangeException("index is greater than Count.");
            BTTClaim_AccessorListAccessor tmpAccessor = collection;
            byte* targetPtr = m_ptr;
            for (int i = 0; i < index; i++)
            {
                {            byte* optheader_1 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_1 + 0) & 0x01)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }

                if ((0 != (*(optheader_1 + 0) & 0x02)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }

                if ((0 != (*(optheader_1 + 0) & 0x04)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }
}
            }
            int offset = (int)(targetPtr - m_ptr);
            m_ptr = ResizeFunction(m_ptr - 4, offset + 4, tmpAccessor.length);
            Memory.Copy(tmpAccessor.m_ptr, m_ptr + offset + 4, tmpAccessor.length);
            *(int*)m_ptr += tmpAccessor.length;
            this.m_ptr += 4;
        }
        /// <summary>
        /// Removes a range of elements from the List.
        /// </summary>
        /// <param name="index">The zero-based starting index of the range of elements to remove.</param>
        /// <param name="count">The number of elements to remove.</param>
        public unsafe void RemoveRange(int index, int count)
        {
            if (index < 0) throw new ArgumentOutOfRangeException("index is less than 0.");
            if (index > Count) throw new ArgumentOutOfRangeException("index is greater than Count.");
            if (index + count > Count) throw new ArgumentException("index and count do not denote a valid range of elements in the List.");
            byte* targetPtr = m_ptr;
            for (int i = 0; i < index; i++)
            {
                {            byte* optheader_1 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_1 + 0) & 0x01)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }

                if ((0 != (*(optheader_1 + 0) & 0x02)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }

                if ((0 != (*(optheader_1 + 0) & 0x04)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }
}
            }
            int offset = (int)(targetPtr - m_ptr);
            byte* oldtargetPtr = targetPtr;
            for (int i = 0; i < count; i++)
            {
                {            byte* optheader_1 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_1 + 0) & 0x01)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }

                if ((0 != (*(optheader_1 + 0) & 0x02)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }

                if ((0 != (*(optheader_1 + 0) & 0x04)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }
}
            }
            int size = (int)(oldtargetPtr - targetPtr);
            m_ptr = ResizeFunction(m_ptr - 4, offset + 4, size);
            *(int*)m_ptr += size;
            this.m_ptr += 4;
        }
        public unsafe static implicit operator List<BTTClaim> (BTTClaim_AccessorListAccessor accessor)
        {
            if((object)accessor == null) return null;
            List<BTTClaim> list = new List<BTTClaim>();
            accessor.ForEach(element => list.Add(element));
            return list;
        }
        
        public unsafe static implicit operator BTTClaim_AccessorListAccessor(List<BTTClaim> field)
        {
            byte* targetPtr = null;
            
{

    targetPtr += sizeof(int);
    if(field!= null)
    {
        for(int iterator_1 = 0;iterator_1<field.Count;++iterator_1)
        {

            {
            targetPtr += 1;

        if(field[iterator_1].key!= null)
        {
            int strlen_3 = field[iterator_1].key.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            if( field[iterator_1].value!= null)
            {

        if(field[iterator_1].value!= null)
        {
            int strlen_3 = field[iterator_1].value.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
            if( field[iterator_1].attribute!= null)
            {

{

    targetPtr += sizeof(int);
    if(field[iterator_1].attribute!= null)
    {
        for(int iterator_3 = 0;iterator_3<field[iterator_1].attribute.Count;++iterator_3)
        {

            {

        if(field[iterator_1].attribute[iterator_3].key!= null)
        {
            int strlen_5 = field[iterator_1].attribute[iterator_3].key.Length * 2;
            targetPtr += strlen_5+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(field[iterator_1].attribute[iterator_3].value!= null)
        {
            int strlen_5 = field[iterator_1].attribute[iterator_3].value.Length * 2;
            targetPtr += strlen_5+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
        }
    }

}

            }
            if( field[iterator_1].attributes!= null)
            {

{

    targetPtr += sizeof(int);
    if(field[iterator_1].attributes!= null)
    {
        for(int iterator_3 = 0;iterator_3<field[iterator_1].attributes.Count;++iterator_3)
        {

{

    targetPtr += sizeof(int);
    if(field[iterator_1].attributes[iterator_3]!= null)
    {
        for(int iterator_4 = 0;iterator_4<field[iterator_1].attributes[iterator_3].Count;++iterator_4)
        {

            {

        if(field[iterator_1].attributes[iterator_3][iterator_4].key!= null)
        {
            int strlen_6 = field[iterator_1].attributes[iterator_3][iterator_4].key.Length * 2;
            targetPtr += strlen_6+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(field[iterator_1].attributes[iterator_3][iterator_4].value!= null)
        {
            int strlen_6 = field[iterator_1].attributes[iterator_3][iterator_4].value.Length * 2;
            targetPtr += strlen_6+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
        }
    }

}

        }
    }

}

            }

            }
        }
    }

}

            byte* tmpcellptr = BufferAllocator.AllocBuffer((int)targetPtr);
            Memory.memset(tmpcellptr, 0, (ulong)targetPtr);
            targetPtr = tmpcellptr;
            
{
byte *storedPtr_1 = targetPtr;

    targetPtr += sizeof(int);
    if(field!= null)
    {
        for(int iterator_1 = 0;iterator_1<field.Count;++iterator_1)
        {

            {
            byte* optheader_2 = targetPtr;
            *(optheader_2 + 0) = 0x00;            targetPtr += 1;

        if(field[iterator_1].key!= null)
        {
            int strlen_3 = field[iterator_1].key.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = field[iterator_1].key)
            {
                Memory.Copy(pstr_3, targetPtr, strlen_3);
                targetPtr += strlen_3;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            if( field[iterator_1].value!= null)
            {

        if(field[iterator_1].value!= null)
        {
            int strlen_3 = field[iterator_1].value.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = field[iterator_1].value)
            {
                Memory.Copy(pstr_3, targetPtr, strlen_3);
                targetPtr += strlen_3;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
*(optheader_2 + 0) |= 0x01;
            }
            if( field[iterator_1].attribute!= null)
            {

{
byte *storedPtr_3 = targetPtr;

    targetPtr += sizeof(int);
    if(field[iterator_1].attribute!= null)
    {
        for(int iterator_3 = 0;iterator_3<field[iterator_1].attribute.Count;++iterator_3)
        {

            {

        if(field[iterator_1].attribute[iterator_3].key!= null)
        {
            int strlen_5 = field[iterator_1].attribute[iterator_3].key.Length * 2;
            *(int*)targetPtr = strlen_5;
            targetPtr += sizeof(int);
            fixed(char* pstr_5 = field[iterator_1].attribute[iterator_3].key)
            {
                Memory.Copy(pstr_5, targetPtr, strlen_5);
                targetPtr += strlen_5;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(field[iterator_1].attribute[iterator_3].value!= null)
        {
            int strlen_5 = field[iterator_1].attribute[iterator_3].value.Length * 2;
            *(int*)targetPtr = strlen_5;
            targetPtr += sizeof(int);
            fixed(char* pstr_5 = field[iterator_1].attribute[iterator_3].value)
            {
                Memory.Copy(pstr_5, targetPtr, strlen_5);
                targetPtr += strlen_5;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            }
        }
    }
*(int*)storedPtr_3 = (int)(targetPtr - storedPtr_3 - 4);

}
*(optheader_2 + 0) |= 0x02;
            }
            if( field[iterator_1].attributes!= null)
            {

{
byte *storedPtr_3 = targetPtr;

    targetPtr += sizeof(int);
    if(field[iterator_1].attributes!= null)
    {
        for(int iterator_3 = 0;iterator_3<field[iterator_1].attributes.Count;++iterator_3)
        {

{
byte *storedPtr_4 = targetPtr;

    targetPtr += sizeof(int);
    if(field[iterator_1].attributes[iterator_3]!= null)
    {
        for(int iterator_4 = 0;iterator_4<field[iterator_1].attributes[iterator_3].Count;++iterator_4)
        {

            {

        if(field[iterator_1].attributes[iterator_3][iterator_4].key!= null)
        {
            int strlen_6 = field[iterator_1].attributes[iterator_3][iterator_4].key.Length * 2;
            *(int*)targetPtr = strlen_6;
            targetPtr += sizeof(int);
            fixed(char* pstr_6 = field[iterator_1].attributes[iterator_3][iterator_4].key)
            {
                Memory.Copy(pstr_6, targetPtr, strlen_6);
                targetPtr += strlen_6;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(field[iterator_1].attributes[iterator_3][iterator_4].value!= null)
        {
            int strlen_6 = field[iterator_1].attributes[iterator_3][iterator_4].value.Length * 2;
            *(int*)targetPtr = strlen_6;
            targetPtr += sizeof(int);
            fixed(char* pstr_6 = field[iterator_1].attributes[iterator_3][iterator_4].value)
            {
                Memory.Copy(pstr_6, targetPtr, strlen_6);
                targetPtr += strlen_6;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            }
        }
    }
*(int*)storedPtr_4 = (int)(targetPtr - storedPtr_4 - 4);

}

        }
    }
*(int*)storedPtr_3 = (int)(targetPtr - storedPtr_3 - 4);

}
*(optheader_2 + 0) |= 0x04;
            }

            }
        }
    }
*(int*)storedPtr_1 = (int)(targetPtr - storedPtr_1 - 4);

}
BTTClaim_AccessorListAccessor ret;
            
            ret = new BTTClaim_AccessorListAccessor(tmpcellptr, null);
            
            return ret;
        }
        
        public static bool operator ==(BTTClaim_AccessorListAccessor a, BTTClaim_AccessorListAccessor b)
        {
            if (ReferenceEquals(a, b))
                return true;
            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;
            if (a.m_ptr == b.m_ptr) return true;
            if (a.length != b.length) return false;
            return Memory.Compare(a.m_ptr, b.m_ptr, a.length);
        }
        public static bool operator !=(BTTClaim_AccessorListAccessor a, BTTClaim_AccessorListAccessor b)
        {
            return !(a == b);
        }
    }
}

#pragma warning restore 162,168,649,660,661,1522
