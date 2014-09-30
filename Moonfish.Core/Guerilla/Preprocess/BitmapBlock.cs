﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Moonfish.Guerilla.Preprocess
{
    public partial class BitmapBlock
    {
        [GuerillaPreProcessMethod( BlockName = "bitmap_block" )]
        protected static void GuerillaPreProcessMethod( BinaryReader binaryReader, IList<tag_field> fields )
        {
            var index = ( from field in fields
                          where field.Name == "WDP fields"
                          select fields.IndexOf( field ) ).Single( );
            var wdpFields = fields.Where( x => fields.IndexOf( x ) >= index && fields.IndexOf( x ) < index + 5 ).ToArray( );
            var dataFields = fields.Where( x => x.type == field_type._field_data ).ToArray( );

            for( int i = 0; i < wdpFields.Count( ); i++ )
            {
                fields.Remove( wdpFields[i] );
            }
            for( int i = 0; i < dataFields.Count( ); i++ )
            {
                index = fields.IndexOf( dataFields[i] );
                fields.RemoveAt( index );
                fields.Insert( index, new tag_field( ) { type = field_type._field_skip, Name = "data", definition = 8 } );
            }
        }
    }
}
