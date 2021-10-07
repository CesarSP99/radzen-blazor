﻿using Microsoft.AspNetCore.Components;

namespace Radzen.Blazor
{
    public class RadzenRadioButtonListItem<TValue> : RadzenComponent
    {
        private string _text;
        [Parameter]
        public string Text
        {
            get
            {
                return _text;
            }
            set
            {
                if (value != _text)
                {
                    _text = value;

                    if (List != null)
                        List.Refresh();
                }
            }
        }

        [Parameter]
        public TValue Value { get; set; }

        [Parameter]
        public virtual bool Disabled { get; set; }

        RadzenRadioButtonList<TValue> _list;

        [CascadingParameter]
        public RadzenRadioButtonList<TValue> List
        {
            get
            {
                return _list;
            }
            set
            {
                if (_list != value)
                {
                    _list = value;
                    _list.AddItem(this);
                }
            }
        }

        public override void Dispose()
        {
            base.Dispose();
            List?.RemoveItem(this);
        }

        internal void SetText(string value)
        {
            Text = value;
        }

        internal void SetValue(TValue value)
        {
            Value = value;
        }
    
        internal void SetDisabled(bool value)
        {
            Disabled = value;
        }

        internal void SetVisible(bool value)
        {
            Visible = value;
        }
    }
}