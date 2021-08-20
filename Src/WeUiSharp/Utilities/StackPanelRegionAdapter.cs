using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WeUiSharp.Interfaces;

namespace WeUiSharp.Utilities
{
    /// <summary>
    /// 
    /// Reference:
    /// Custome StackPanel Prism RegionAdapter to support Ordering
    /// https://stackoverflow.com/a/17638330
    /// </summary>
    public class StackPanelRegionAdapter: RegionAdapterBase<StackPanel>
    {
        private readonly List<int> _IndexList;

        public StackPanelRegionAdapter(IRegionBehaviorFactory regionBehaviorFactory)
            : base(regionBehaviorFactory)
        {
            _IndexList = new List<int>();
        }

        protected override void Adapt(IRegion region, StackPanel regionTarget)
        {
            region.Views.CollectionChanged += (s, e) =>
            {
                //Add
                if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
                {
                    foreach (FrameworkElement element in e.NewItems)
                    {
                        // Get index for view
                        var sortedView = element as ISortedView;
                        if (sortedView != null)
                        {
                            var viewIndex = sortedView.Index;
                            // This method needs to iterate through the views in the region and determine
                            // where a view with the specified index needs to be inserted
                            var insertionIndex = GetInsertionIndex(viewIndex);
                            regionTarget.Children.Insert(insertionIndex, (UIElement)sortedView);
                        }
                        else
                        { 
                            // Add at the end of the StackPanel or reject adding the view to the region
                            regionTarget.Children.Add(element);
                        }
                            
                    }
                }
                //Remove
                if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
                {
                    foreach (FrameworkElement element in e.OldItems)
                    {
                        regionTarget.Children.Remove(element);
                    }
                }
            };
        }

        private int GetInsertionIndex(in int viewIndex)
        {
            // Add the viewIndex to the index list if not already there
            if (_IndexList.Contains(viewIndex) == false)
            {
                _IndexList.Add(viewIndex);
                _IndexList.Sort();
            }

            // Return the list index of the viewIndex
            for (var i = 0; i < _IndexList.Count; i++)
            {
                if (_IndexList[i].Equals(viewIndex))
                {
                    return i;
                }
            }

            return 0;
        }
        protected override IRegion CreateRegion()
        {
            return new AllActiveRegion();
        }
    }
}
