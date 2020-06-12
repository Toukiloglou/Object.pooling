using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PoolManager : MonoSingleton<PoolManager>
{
    [SerializeField]
    private GameObject _itemPrefab;

    [SerializeField]
    private int poolSize;

    [SerializeField]
    private GameObject itemContainer;

    [SerializeField]
    private List<GameObject> _itemPool;

    public override void Init() {
        base.Init();
        _itemPool.Clear();
        _itemPool = GenerateItems(poolSize);        
    }

    private void NewItem(bool active) {
        GameObject item = Instantiate(_itemPrefab);
        item.transform.parent = itemContainer.transform;
        item.SetActive(active);
        _itemPool.Add(item);        
    }

    List<GameObject> GenerateItems(int ammoutsOfitems) {
        for (int i = 0; i < ammoutsOfitems; i++) {
            NewItem(false);
        } 
        return _itemPool;
    }

    public GameObject RequestItem() {

        foreach (var item in _itemPool) {
            if(item.activeInHierarchy == false) {
                item.SetActive(true);
                return item;
            }
        }

        // Create new items if size of pool is reached
        NewItem(true);
        return _itemPool.Last();      
    }

}
