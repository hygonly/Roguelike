using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

namespace HYG.Collections.Generic
{
    [Serializable]
    public class SerializedDictionary<TKey, TValue>
    {
        [Serializable]
        public class DictionaryItem
        {
            public TKey Key { get { return mKey; } }
            public TValue Value { get { return mValue; } set { mValue = value; } }

            [SerializeField] private TKey mKey;
            [SerializeField] private TValue mValue;

            public DictionaryItem(TKey key, TValue value)
            {
                mKey = key;
                mValue = value;
            }
        }

        [SerializeField] private List<DictionaryItem> mItems = new List<DictionaryItem>();

        public TValue this[TKey key]
        {
            get
            {
                var item = mItems.Find(_ => EqualityComparer<TKey>.Default.Equals(_.Key, key));
                if (item == null)
                    throw new KeyNotFoundException($"Key not found: {key}");

                return item.Value;
            }
            set
            {
                var item = mItems.Find(_ => EqualityComparer<TKey>.Default.Equals(_.Key, key));
                if (item == null)
                    throw new KeyNotFoundException($"Key not found: {key}");
                else
                    item.Value = value;

            }
        }

        public void Add(TKey key, TValue value)
        {
            var item = new DictionaryItem(key, value);
            mItems.Add(item);
        }

        public bool Remove(TKey key)
        {
            int index = mItems.FindIndex(_ => EqualityComparer<TKey>.Default.Equals(_.Key, key));
            if (index < 0)
                return false;

            var item = mItems[index];
            mItems.Remove(item);
            return true;
        }

        public bool ContainsKey(TKey key)
        {
            int index = mItems.FindIndex(_ => EqualityComparer<TKey>.Default.Equals(_.Key, key));
            if (index < 0)
                return false;

            return true;
        }

        public TValue GetValueOrDefault(TKey key)
        {
            int index = mItems.FindIndex(_ => EqualityComparer<TKey>.Default.Equals(_.Key, key));
            if (index < 0)
                return default;

            var item = mItems[index];
            return item.Value;
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            TValue item = GetValueOrDefault(key);
            if (item == null)
            {
                value = default;
                return false;
            }

            value = item;
            return true;
        }
    }
}
