namespace NeighbouringCountries.DataStructures
{
    internal class HashMapImplementation<K, V>
    {
        private class HashMapNode
        {
            public K key;
            public V value;

            public HashMapNode(K key, V value)
            {
                this.key = key;
                this.value = value;
            }
        }

        private int size; //n
        private LinkedListImplementation<HashMapNode>[]? buckets; // N = buckets.length

        public HashMapImplementation()
        {
            InitBuckets(4);
            size = 0;
        }
        
        private void InitBuckets(int bucketSize)
        {
            buckets = new LinkedListImplementation<HashMapNode>[bucketSize];
            for(int bucketIndex = 0; bucketIndex<buckets.Length; bucketIndex++)
            {
                buckets[bucketIndex] = new LinkedListImplementation<HashMapNode>();
            }
        }

        public void Put(K key, V value)
        {
            int bucketIndex = GetBucketHash(key);
            int dataIndex = GetIndexWithinBucket(key, bucketIndex);

            if(dataIndex != -1)
            {
                HashMapNode node = buckets[bucketIndex].Get(dataIndex);
                node.value = value;
            }

            else
            {
                HashMapNode node = new HashMapNode(key, value);
                buckets[bucketIndex].Enqueue(node);
                size++;
            }

            double lambda = size * 1.0 / buckets.Length;

            if(lambda > 2)
            {
                Rehash();
            }
        }

        private void Rehash()
        {
            LinkedListImplementation<HashMapNode>[] oldBucketArray = buckets;
            InitBuckets(oldBucketArray.Length * 2);
            size = 0;

            for(int i=0; i<oldBucketArray.Length; i++)
            {
                foreach(HashMapNode node in oldBucketArray[i])
                {
                    Put(node.key, node.value);
                }
            }
        }
        
        private int GetBucketHash(K key)
        {
            int hashCode = key.GetHashCode();
            return Math.Abs(hashCode) % buckets.Length;
        }

        private int GetIndexWithinBucket(K key, int bucketIndex)
        {
            int dataIndex = 0;
            foreach (HashMapNode node in buckets[bucketIndex])
            {
                if (node.key.Equals(key))
                {
                    return dataIndex;
                }
                dataIndex++;
            }
            return -1;
        }

        public Boolean ContainsKey(K key)
        {
            int bucketIndex = GetBucketHash(key);
            int dataIndex = GetIndexWithinBucket(key, bucketIndex);
            if(dataIndex != -1)
            {
                return true;
            }
            return false;
        }

        public V Get(K key)
        {
            int bucketIndex = GetBucketHash(key);
            int dataIndex = GetIndexWithinBucket(key, bucketIndex);

            if(dataIndex != -1)
            {
                HashMapNode node = buckets[bucketIndex].Get(dataIndex);
                return node.value;
            }
            else
            {
                return default(V);
            }
        }
    }
}
