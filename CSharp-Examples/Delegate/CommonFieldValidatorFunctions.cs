using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Delegate
{
    public delegate bool RequiredValidDel(string fieldVal);
    public delegate bool StringLengthValidDel(string fieldVal);

    public delegate bool AllCustomValidDel(string fieldVal);

    public class CommonFieldValidatorFunctions
    {
        private static RequiredValidDel _requiredValidDel;
        private static StringLengthValidDel _stringLengthValidDel;

        private static AllCustomValidDel _allCustomRequiredValidDel;
        private static AllCustomValidDel _allCustomStringLengthValidDel;
        private static AllCustomValidDel _allCustomValidDel;

        public static RequiredValidDel RequiredFieldValidDel
        {
            get
            {
                if (_requiredValidDel == null)
                    _requiredValidDel = new RequiredValidDel(RequiredFieldValid);

                return _requiredValidDel;
            }
        }

        public static StringLengthValidDel StringLengthFieldValidDel
        {
            get
            {
                if (_stringLengthValidDel == null)
                    _stringLengthValidDel = new StringLengthValidDel(StringFieldLengthValid);

                return _stringLengthValidDel;
            }
        }

        public static AllCustomValidDel AllCustomRequiredValidDel
        {
            get
            {
                if (_allCustomRequiredValidDel == null)
                    _allCustomRequiredValidDel = new AllCustomValidDel(RequiredFieldValid);

                return _allCustomRequiredValidDel;
            }
        }

        public static AllCustomValidDel AllCustomStringLengthValidDel
        {
            get
            {
                if (_allCustomStringLengthValidDel == null)
                    _allCustomStringLengthValidDel = new AllCustomValidDel(StringFieldLengthValid);

                return _allCustomStringLengthValidDel;
            }
        }

        public static AllCustomValidDel AllCustomValidDel
        {
            get
            {
                if (_allCustomValidDel == null)
                    _allCustomValidDel = AllCustomRequiredValidDel + AllCustomStringLengthValidDel;

                return _allCustomValidDel;
            }
        }


        private static bool RequiredFieldValid(string fieldVal)
        {
            if (!string.IsNullOrEmpty(fieldVal))
                return true;

            return false;

        }

        private static bool StringFieldLengthValid(string fieldVal)
        {
            if (fieldVal.Length >= 10 && fieldVal.Length <= 20)
                return true;

            return false;

        }
    }
}
