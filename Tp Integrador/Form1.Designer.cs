﻿namespace Tp_Integrador
{
    partial class FormCatalogo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvListaArticulos = new System.Windows.Forms.DataGridView();
            this.pBoxArticulo = new System.Windows.Forms.PictureBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnEliminarFisico = new System.Windows.Forms.Button();
            this.btnEliminarLogico = new System.Windows.Forms.Button();
            this.btnActivar = new System.Windows.Forms.Button();
            this.btnActivarArticulo = new System.Windows.Forms.Button();
            this.btnCancelarActivar = new System.Windows.Forms.Button();
            this.labelFiltroSimple = new System.Windows.Forms.Label();
            this.tBoxFiltroSimple = new System.Windows.Forms.TextBox();
            this.btnFiltroAvanzado = new System.Windows.Forms.Button();
            this.labelCampo = new System.Windows.Forms.Label();
            this.labelCriterio = new System.Windows.Forms.Label();
            this.labelFiltroAvanzado = new System.Windows.Forms.Label();
            this.cBoxCampo = new System.Windows.Forms.ComboBox();
            this.cBoxCriterio = new System.Windows.Forms.ComboBox();
            this.tBoxFiltroAvanzado = new System.Windows.Forms.TextBox();
            this.btnVolver = new System.Windows.Forms.Button();
            this.btnVerDetalle = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaArticulos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxArticulo)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvListaArticulos
            // 
            this.dgvListaArticulos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaArticulos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvListaArticulos.Location = new System.Drawing.Point(25, 55);
            this.dgvListaArticulos.MultiSelect = false;
            this.dgvListaArticulos.Name = "dgvListaArticulos";
            this.dgvListaArticulos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListaArticulos.Size = new System.Drawing.Size(688, 265);
            this.dgvListaArticulos.TabIndex = 0;
            this.dgvListaArticulos.SelectionChanged += new System.EventHandler(this.dgvListaArticulos_SelectionChanged);
            // 
            // pBoxArticulo
            // 
            this.pBoxArticulo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pBoxArticulo.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.pBoxArticulo.Location = new System.Drawing.Point(748, 74);
            this.pBoxArticulo.Name = "pBoxArticulo";
            this.pBoxArticulo.Size = new System.Drawing.Size(184, 226);
            this.pBoxArticulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pBoxArticulo.TabIndex = 1;
            this.pBoxArticulo.TabStop = false;
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.SystemColors.MenuBar;
            this.btnAgregar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.Font = new System.Drawing.Font("High Tower Text", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnAgregar.Location = new System.Drawing.Point(25, 339);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(101, 29);
            this.btnAgregar.TabIndex = 0;
            this.btnAgregar.Text = "&AGREGAR";
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.BackColor = System.Drawing.SystemColors.MenuBar;
            this.btnModificar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnModificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModificar.Font = new System.Drawing.Font("High Tower Text", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificar.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnModificar.Location = new System.Drawing.Point(171, 339);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(101, 29);
            this.btnModificar.TabIndex = 1;
            this.btnModificar.Text = "&MODIFICAR";
            this.btnModificar.UseVisualStyleBackColor = false;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnEliminarFisico
            // 
            this.btnEliminarFisico.BackColor = System.Drawing.SystemColors.MenuBar;
            this.btnEliminarFisico.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminarFisico.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarFisico.Font = new System.Drawing.Font("High Tower Text", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarFisico.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnEliminarFisico.Location = new System.Drawing.Point(317, 339);
            this.btnEliminarFisico.Name = "btnEliminarFisico";
            this.btnEliminarFisico.Size = new System.Drawing.Size(101, 29);
            this.btnEliminarFisico.TabIndex = 2;
            this.btnEliminarFisico.Text = "&ELIMINAR ";
            this.btnEliminarFisico.UseVisualStyleBackColor = false;
            this.btnEliminarFisico.Click += new System.EventHandler(this.btnEliminarFisico_Click);
            // 
            // btnEliminarLogico
            // 
            this.btnEliminarLogico.BackColor = System.Drawing.SystemColors.MenuBar;
            this.btnEliminarLogico.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminarLogico.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarLogico.Font = new System.Drawing.Font("High Tower Text", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarLogico.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnEliminarLogico.Location = new System.Drawing.Point(463, 339);
            this.btnEliminarLogico.Name = "btnEliminarLogico";
            this.btnEliminarLogico.Size = new System.Drawing.Size(104, 29);
            this.btnEliminarLogico.TabIndex = 3;
            this.btnEliminarLogico.Text = "&DESACTIVAR";
            this.btnEliminarLogico.UseVisualStyleBackColor = false;
            this.btnEliminarLogico.Click += new System.EventHandler(this.btnEliminarLogico_Click);
            // 
            // btnActivar
            // 
            this.btnActivar.BackColor = System.Drawing.SystemColors.MenuBar;
            this.btnActivar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnActivar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActivar.Font = new System.Drawing.Font("High Tower Text", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActivar.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnActivar.Location = new System.Drawing.Point(609, 339);
            this.btnActivar.Name = "btnActivar";
            this.btnActivar.Size = new System.Drawing.Size(101, 29);
            this.btnActivar.TabIndex = 4;
            this.btnActivar.Text = " ACTIVA&R       ";
            this.btnActivar.UseVisualStyleBackColor = false;
            this.btnActivar.Click += new System.EventHandler(this.btnActivar_Click);
            // 
            // btnActivarArticulo
            // 
            this.btnActivarArticulo.BackColor = System.Drawing.SystemColors.MenuBar;
            this.btnActivarArticulo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnActivarArticulo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActivarArticulo.Font = new System.Drawing.Font("High Tower Text", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActivarArticulo.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnActivarArticulo.Location = new System.Drawing.Point(171, 404);
            this.btnActivarArticulo.Name = "btnActivarArticulo";
            this.btnActivarArticulo.Size = new System.Drawing.Size(101, 29);
            this.btnActivarArticulo.TabIndex = 5;
            this.btnActivarArticulo.Text = "ACT&IVAR";
            this.btnActivarArticulo.UseVisualStyleBackColor = false;
            this.btnActivarArticulo.Click += new System.EventHandler(this.btnActivarArticulo_Click);
            // 
            // btnCancelarActivar
            // 
            this.btnCancelarActivar.BackColor = System.Drawing.SystemColors.MenuBar;
            this.btnCancelarActivar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelarActivar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelarActivar.Font = new System.Drawing.Font("High Tower Text", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelarActivar.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnCancelarActivar.Location = new System.Drawing.Point(385, 404);
            this.btnCancelarActivar.Name = "btnCancelarActivar";
            this.btnCancelarActivar.Size = new System.Drawing.Size(101, 29);
            this.btnCancelarActivar.TabIndex = 6;
            this.btnCancelarActivar.Text = "&CANCELAR";
            this.btnCancelarActivar.UseVisualStyleBackColor = false;
            this.btnCancelarActivar.Click += new System.EventHandler(this.btnCancelarActivar_Click);
            // 
            // labelFiltroSimple
            // 
            this.labelFiltroSimple.AutoSize = true;
            this.labelFiltroSimple.Location = new System.Drawing.Point(22, 26);
            this.labelFiltroSimple.Name = "labelFiltroSimple";
            this.labelFiltroSimple.Size = new System.Drawing.Size(32, 13);
            this.labelFiltroSimple.TabIndex = 7;
            this.labelFiltroSimple.Text = "Filtro:";
            // 
            // tBoxFiltroSimple
            // 
            this.tBoxFiltroSimple.Location = new System.Drawing.Point(63, 22);
            this.tBoxFiltroSimple.Name = "tBoxFiltroSimple";
            this.tBoxFiltroSimple.Size = new System.Drawing.Size(155, 20);
            this.tBoxFiltroSimple.TabIndex = 8;
            this.tBoxFiltroSimple.TextChanged += new System.EventHandler(this.tBoxFiltroSimple_TextChanged);
            // 
            // btnFiltroAvanzado
            // 
            this.btnFiltroAvanzado.Location = new System.Drawing.Point(828, 520);
            this.btnFiltroAvanzado.Name = "btnFiltroAvanzado";
            this.btnFiltroAvanzado.Size = new System.Drawing.Size(138, 24);
            this.btnFiltroAvanzado.TabIndex = 9;
            this.btnFiltroAvanzado.Text = "Buscar";
            this.btnFiltroAvanzado.UseVisualStyleBackColor = true;
            this.btnFiltroAvanzado.Click += new System.EventHandler(this.btnFiltroAvanzado_Click);
            // 
            // labelCampo
            // 
            this.labelCampo.AutoSize = true;
            this.labelCampo.Location = new System.Drawing.Point(24, 526);
            this.labelCampo.Name = "labelCampo";
            this.labelCampo.Size = new System.Drawing.Size(43, 13);
            this.labelCampo.TabIndex = 10;
            this.labelCampo.Text = "Campo:";
            // 
            // labelCriterio
            // 
            this.labelCriterio.AutoSize = true;
            this.labelCriterio.Location = new System.Drawing.Point(296, 526);
            this.labelCriterio.Name = "labelCriterio";
            this.labelCriterio.Size = new System.Drawing.Size(42, 13);
            this.labelCriterio.TabIndex = 11;
            this.labelCriterio.Text = "Criterio:";
            // 
            // labelFiltroAvanzado
            // 
            this.labelFiltroAvanzado.AutoSize = true;
            this.labelFiltroAvanzado.Location = new System.Drawing.Point(567, 526);
            this.labelFiltroAvanzado.Name = "labelFiltroAvanzado";
            this.labelFiltroAvanzado.Size = new System.Drawing.Size(32, 13);
            this.labelFiltroAvanzado.TabIndex = 12;
            this.labelFiltroAvanzado.Text = "Filtro:";
            // 
            // cBoxCampo
            // 
            this.cBoxCampo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxCampo.FormattingEnabled = true;
            this.cBoxCampo.Location = new System.Drawing.Point(105, 523);
            this.cBoxCampo.Name = "cBoxCampo";
            this.cBoxCampo.Size = new System.Drawing.Size(153, 21);
            this.cBoxCampo.TabIndex = 13;
            this.cBoxCampo.SelectedIndexChanged += new System.EventHandler(this.cBoxCampo_SelectedIndexChanged);
            // 
            // cBoxCriterio
            // 
            this.cBoxCriterio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxCriterio.FormattingEnabled = true;
            this.cBoxCriterio.Location = new System.Drawing.Point(376, 523);
            this.cBoxCriterio.Name = "cBoxCriterio";
            this.cBoxCriterio.Size = new System.Drawing.Size(153, 21);
            this.cBoxCriterio.TabIndex = 14;
            // 
            // tBoxFiltroAvanzado
            // 
            this.tBoxFiltroAvanzado.Location = new System.Drawing.Point(637, 523);
            this.tBoxFiltroAvanzado.Name = "tBoxFiltroAvanzado";
            this.tBoxFiltroAvanzado.Size = new System.Drawing.Size(153, 20);
            this.tBoxFiltroAvanzado.TabIndex = 15;
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(828, 560);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(138, 24);
            this.btnVolver.TabIndex = 16;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // btnVerDetalle
            // 
            this.btnVerDetalle.BackColor = System.Drawing.SystemColors.MenuBar;
            this.btnVerDetalle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVerDetalle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerDetalle.Font = new System.Drawing.Font("High Tower Text", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerDetalle.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnVerDetalle.Location = new System.Drawing.Point(790, 329);
            this.btnVerDetalle.Name = "btnVerDetalle";
            this.btnVerDetalle.Size = new System.Drawing.Size(101, 49);
            this.btnVerDetalle.TabIndex = 17;
            this.btnVerDetalle.Text = "&VER DETALLE";
            this.btnVerDetalle.UseVisualStyleBackColor = false;
            this.btnVerDetalle.Click += new System.EventHandler(this.btnVerDetalle_Click);
            // 
            // FormCatalogo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1084, 675);
            this.Controls.Add(this.btnVerDetalle);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.tBoxFiltroAvanzado);
            this.Controls.Add(this.cBoxCriterio);
            this.Controls.Add(this.cBoxCampo);
            this.Controls.Add(this.labelFiltroAvanzado);
            this.Controls.Add(this.labelCriterio);
            this.Controls.Add(this.labelCampo);
            this.Controls.Add(this.btnFiltroAvanzado);
            this.Controls.Add(this.tBoxFiltroSimple);
            this.Controls.Add(this.labelFiltroSimple);
            this.Controls.Add(this.btnCancelarActivar);
            this.Controls.Add(this.btnActivarArticulo);
            this.Controls.Add(this.btnActivar);
            this.Controls.Add(this.btnEliminarLogico);
            this.Controls.Add(this.btnEliminarFisico);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.pBoxArticulo);
            this.Controls.Add(this.dgvListaArticulos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximumSize = new System.Drawing.Size(1104, 718);
            this.MinimumSize = new System.Drawing.Size(1104, 718);
            this.Name = "FormCatalogo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Catálogo";
            this.Load += new System.EventHandler(this.FormCatalogo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaArticulos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxArticulo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvListaArticulos;
        private System.Windows.Forms.PictureBox pBoxArticulo;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnEliminarFisico;
        private System.Windows.Forms.Button btnEliminarLogico;
        private System.Windows.Forms.Button btnActivar;
        private System.Windows.Forms.Button btnActivarArticulo;
        private System.Windows.Forms.Button btnCancelarActivar;
        private System.Windows.Forms.Label labelFiltroSimple;
        private System.Windows.Forms.TextBox tBoxFiltroSimple;
        private System.Windows.Forms.Button btnFiltroAvanzado;
        private System.Windows.Forms.Label labelCampo;
        private System.Windows.Forms.Label labelCriterio;
        private System.Windows.Forms.Label labelFiltroAvanzado;
        private System.Windows.Forms.ComboBox cBoxCampo;
        private System.Windows.Forms.ComboBox cBoxCriterio;
        private System.Windows.Forms.TextBox tBoxFiltroAvanzado;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Button btnVerDetalle;
    }
}

