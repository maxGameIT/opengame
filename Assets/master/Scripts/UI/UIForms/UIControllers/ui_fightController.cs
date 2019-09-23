using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace Master
{

    public partial class ui_fight : UGuiForm
    {
        [SerializeField]
         const int Row = 6;
        [SerializeField]
        const int Colum = 7;
        private item[,] items;
        [Serializable]
        public struct ItemPrefab
        {
            public item.ItemType type;
            public GameObject prefab;
        }
        public ItemPrefab[] ItemPrefabs;
        Dictionary<item.ItemType, GameObject> itemprefabDict;
        private item pressedItem;
        private item enterItem;


        protected override void OnOpen(object userData)
        {
            base.OnOpen(userData);
            itemprefabDict = new Dictionary<item.ItemType, GameObject>();
            for (int i = 0; i < ItemPrefabs.Length; i++)
            {
                if(!itemprefabDict.ContainsKey(ItemPrefabs[i].type))
                {
                    itemprefabDict.Add(ItemPrefabs[i].type, ItemPrefabs[i].prefab);
                }
            }
            CreateItems();
            StartCoroutine(AllFill());
        }



        void CreateItems()
        {
            items = new item[Colum, Row];
            for (int i = 0; i < Colum; i++)
            {
                for (int j = 0; j < Row; j++)
                {
                    PageView view = view_items.transform.GetChild(0).GetComponent<PageView>();
                    item it = CreateNewItem(i,j, item.ItemType.EMPTY, view.content.GetChild(0));
                    //if (it.CanColor())
                    //{
                    //    it.Coloritem.SetColor((ColorItem.ColorType)UnityEngine.Random.Range(0,it.Coloritem.NumColors));
                    //}
                }
            }
        }

        public item CreateNewItem(int x,int y, item.ItemType type,Transform parent = null)
        {
            GameObject child = GameObject.Instantiate(itemprefabDict[type], parent);
            item it = child.GetComponent<item>();
            it.init(x,y,type);
            items[x, y] = it;
            return it;
        }

        public float fillTime =0.3f;

        public IEnumerator AllFill()
        {
            while (Fill())
            {
               yield return new WaitForSeconds(fillTime);
            }
        }

        public bool Fill()
        {
            bool FilledNotFinshed = false;
            PageView view = view_items.transform.GetChild(0).GetComponent<PageView>();
            for (int i = 0; i < Colum; i++)
            {
                for (int j = Row -2; j >= 0; j--)
                {
                    item it = items[i, j];
                    if (it.CanMove())
                    {
                        item sweetbelow = items[i, j + 1];
                        if (sweetbelow.Type == item.ItemType.EMPTY)
                        {
                            it.Moveitem.Move(i,j+1,fillTime);
                            Destroy(items[i, j + 1].gameObject);
                            items[i, j + 1] = it;
                            CreateNewItem(i,j,item.ItemType.EMPTY, view.content.GetChild(0));
                            FilledNotFinshed = true;
                        }
                    }
                }


            }

            for (int x = 0; x < Colum; x++)
            {
                item it = items[x, 0];
                if (it.Type == item.ItemType.EMPTY)
                {
                    Destroy(items[x, 0].gameObject);
                    GameObject newitem = GameObject.Instantiate(itemprefabDict[item.ItemType.NORMAL], view.content.GetChild(0));
                    items[x, 0] = newitem.GetComponent<item>();
                    items[x, 0].init(x, -1, item.ItemType.NORMAL);
                    items[x, 0].Moveitem.Move(x, 0,fillTime);
                    items[x, 0].Coloritem.SetColor((ColorItem.ColorType)UnityEngine.Random.Range(0, items[x, 0].Coloritem.NumColors));
                    FilledNotFinshed = true;
                }
            }

            return FilledNotFinshed;
        }


        private bool IsBetween(item item1, item item2)
        {
            return (item1.X == item2.X && Mathf.Abs(item1.Y - item2.Y) == 1) || 
                (item1.Y == item2.Y && Mathf.Abs(item1.X - item2.X) == 1);
        }

        public void ExchangeItems(item item1, item item2)
        {
            if (item1.CanMove() && item2.CanMove())
            {
                items[item1.X, item1.Y] = item2;
                items[item2.X, item2.Y] = item1;
                int tempX = item1.X;
                int tempY = item1.Y;
                item1.Moveitem.Move(item2.X,item2.Y,fillTime);
                item2.Moveitem.Move(tempX, tempY, fillTime);
            }
        }

        public void PressItem(item item)
        {
            pressedItem = item;
        }

        public void EnterItem(item item)
        {
            enterItem = item;
        }

        public bool ReleaseItem()
        {
            if (IsBetween(pressedItem,enterItem))
            {
                ExchangeItems(pressedItem, enterItem);
                return true;
            }
            return false;
        }

        protected override void OnUpdate(float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(elapseSeconds, realElapseSeconds);
        }


        protected override void OnResume()
        {
           
        }

       

        protected override void OnReveal()
        {
          

        }

      

       
    }

}
