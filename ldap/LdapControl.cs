﻿using System;
using System.Security.Cryptography;
using zivillian.ldap.Asn1;

namespace zivillian.ldap
{
    public class LdapControl
    {
        internal LdapControl(Asn1Control control)
        {
            Oid = control.ControlType;
            Criticality = control.Criticality;
            Value = control.ControlValue;
        }

        public ReadOnlyMemory<byte> Value { get; set; }

        public bool Criticality { get; }

        public Oid Oid { get; }

        internal static LdapControl[] Create(Asn1Control[] controls)
        {
            if (controls == null)
                return new LdapControl[0];
            var result = new LdapControl[controls.Length];
            for (int i = 0; i < controls.Length; i++)
            {
                result[i] = new LdapControl(controls[i]);
            }
            return result;
        }
    }
}